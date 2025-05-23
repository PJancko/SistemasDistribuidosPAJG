const express = require('express');
const { graphqlHTTP } = require('express-graphql');
const { buildSchema } = require('graphql');
const mysql = require('mysql2/promise');
const cors = require('cors');

// Conexión a MySQL
const pool = mysql.createPool({
  host: 'localhost',
  user: 'root',
  password: '',
  database: 'segip'
});

// Esquema GraphQL
const schema = buildSchema(`
  type Deuda {
    Entidad: String
    Codigo: String
    Concepto: String
    Monto: Float
  }

  type Persona {
    ci: String
    nombres: String
    PrimerApellido: String
    SegundoApellido: String
    deudas: [Deuda]
  }

  type Query {
    persona(ci: String!): Persona
  }
`);

// Resolver real con consultas MySQL
const root = {
  persona: async ({ ci }) => {
    const conn = await pool.getConnection();

    try {
      // Obtener datos de la persona
      const [personas] = await conn.query(
        'SELECT * FROM personas WHERE ci = ?', [ci]
      );

      if (personas.length === 0) return null;

      const persona = personas[0];

      // Obtener sus deudas
      const [deudas] = await conn.query(
        'SELECT Entidad, Codigo, Concepto, Monto FROM deudas WHERE ci = ?', [ci]
      );

      return {
        ...persona,
        deudas
      };

    } finally {
      conn.release();
    }
  }
};

const app = express();
app.use(cors());

app.use('/graphql', graphqlHTTP({
  schema,
  rootValue: root,
  graphiql: true
}));

app.listen(4000, () => {
  console.log('SEGIP GraphQL corriendo en http://localhost:4000/graphql');
});
