// routes/facturaRoutes.js
const express = require('express');
const router = express.Router();
const db = require('../db');

// GET /facturas/:ci
router.get('/:ci', async (req, res) => {
  try {
    const [rows] = await db.query('SELECT * FROM facturas WHERE ci = ?', [req.params.ci]);
    res.json(rows);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

// PUT /facturas/:nro_factura
router.put('/:nro_factura', async (req, res) => {
  try {
    const [rows] = await db.query('UPDATE facturas SET estado = "Pagado" WHERE nro_factura = ?', [req.params.nro_factura]);

    if (rows.affectedRows === 0) {
      return res.status(404).json({ error: 'Factura no encontrada' });
    }

    res.json({ mensaje: 'Factura pagada correctamente' });
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

module.exports = router;
