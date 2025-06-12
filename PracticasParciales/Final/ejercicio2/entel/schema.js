// schema.js
const { GraphQLObjectType, GraphQLString, GraphQLList, GraphQLSchema } = require('graphql');
const pool = require('./db');

const FacturaType = new GraphQLObjectType({
  name: 'Factura',
  fields: {
    empresa: { type: GraphQLString },
    nro_factura: { type: GraphQLString },
    ci: { type: GraphQLString },
    nombre_completo: { type: GraphQLString },
    periodo: { type: GraphQLString },
    monto: { type: GraphQLString },
    estado: { type: GraphQLString }
  }
});

const RootQuery = new GraphQLObjectType({
  name: 'RootQueryType',
  fields: {
    facturasPorCI: {
      type: new GraphQLList(FacturaType),
      args: { ci: { type: GraphQLString } },
      resolve: async (_, { ci }) => {
        const [rows] = await pool.query('SELECT * FROM facturas WHERE ci = ?', [ci]);
        return rows;
      }
    }
  }
});

const Mutation = new GraphQLObjectType({
  name: 'Mutation',
  fields: {
    pagarFactura: {
      type: GraphQLString,
      args: { nro_factura: { type: GraphQLString } },
      resolve: async (_, { nro_factura }) => {
        const [result] = await pool.query('UPDATE facturas SET estado = "Pagado" WHERE nro_factura = ?', [nro_factura]);
        if (result.affectedRows === 0) {
          throw new Error('Factura no encontrada');
        }
        return 'Factura pagada correctamente';
      }
    }
  }
});

module.exports = new GraphQLSchema({
  query: RootQuery,
  mutation: Mutation
});
