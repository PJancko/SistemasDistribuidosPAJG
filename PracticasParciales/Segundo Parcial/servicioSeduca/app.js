const express = require('express');
const { ApolloServer, gql } = require('apollo-server-express');
const mysql = require('mysql2/promise');

// Conexión a MySQL
const dbConfig = {
  host: 'localhost',
  user: 'root',
  password: '',
  database: 'seduca',
};

// Esquema GraphQL
const typeDefs = gql`
  type Persona {
    CI: String!
    Nombres: String!
    PrimerApellido: String!
    SegundoApellido: String!
    EsBachiller: Boolean!
  }

  type Query {
    persona(ci: String!): Persona
  }
`;

// Resolver con consulta a MySQL
const resolvers = {
  Query: {
    persona: async (_, { ci }) => {
      const conn = await mysql.createConnection(dbConfig);
      const [rows] = await conn.execute(
        `SELECT ci, nombres, primer_apellido, segundo_apellido, es_bachiller FROM personas WHERE ci = ? LIMIT 1`,
        [ci]
      );
      await conn.end();

      if (rows.length === 0) return null;

      const p = rows[0];
      return {
        CI: p.ci,
        Nombres: p.nombres,
        PrimerApellido: p.primer_apellido,
        SegundoApellido: p.segundo_apellido,
        EsBachiller: !!p.es_bachiller,
      };
    }
  }
};

// Servidor
async function startServer() {
  const app = express();
  const server = new ApolloServer({ typeDefs, resolvers });

  await server.start();
  server.applyMiddleware({ app });

  app.listen(4000, () =>
    console.log(`🚀 SEDUCA GraphQL ready at http://localhost:4000${server.graphqlPath}`)
  );
}

startServer();
