// index.js
const express = require('express');
const cors = require('cors');
const facturaRoutes = require('./routes/facturaRoutes');

const app = express();
app.use(cors());
app.use(express.json());

app.use('/facturas', facturaRoutes);

app.listen(3001, () => {
  console.log('Elapas (MySQL) corriendo en http://localhost:3001');
});
