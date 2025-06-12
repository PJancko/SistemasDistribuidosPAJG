// db.js
const mysql = require('mysql2/promise');

const pool = mysql.createPool({
  host: 'localhost',
  user: 'root',
  password: '', // cambia si tu contraseña es distinta
  database: 'elapas'
});

module.exports = pool;
