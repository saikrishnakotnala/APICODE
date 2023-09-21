const express = require('express');
const bodyParser = require('body-parser');
const app = express();

// Middleware to parse JSON requests
app.use(bodyParser.json());

// Sample data (in-memory storage)
const items = [];

// Create an item
app.post('/items', (req, res) => {
  const newItem = req.body;
  if (newItem.name) {
    newItem.id = items.length + 1;
    items.push(newItem);
    res.status(201).json(newItem);
  } else {
    res.status(400).json({ error: 'Name is required' });
  }
});

// Read all items
app.get('/items', (req, res) => {
  res.json({ items });
});

// Read a specific item
app.get('/items/:id', (req, res) => {
  const itemId = parseInt(req.params.id);
  const item = items.find((item) => item.id === itemId);
  if (item) {
    res.json(item);
  } else {
    res.status(404).json({ error: 'Item not found' });
  }
});

// Update an item
app.put('/items/:id', (req, res) => {
  const itemId = parseInt(req.params.id);
  const updatedItem = req.body;
  const itemIndex = items.findIndex((item) => item.id === itemId);
  if (itemIndex !== -1) {
    items[itemIndex] = { ...items[itemIndex], ...updatedItem };
    res.json(items[itemIndex]);
  } else {
    res.status(404).json({ error: 'Item not found' });
  }
});

// Delete an item
app.delete('/items/:id', (req, res) => {
  const itemId = parseInt(req.params.id);
  const itemIndex = items.findIndex((item) => item.id === itemId);
  if (itemIndex !== -1) {
    items.splice(itemIndex, 1);
    res.json({ message: 'Item deleted' });
  } else {
    res.status(404).json({ error: 'Item not found' });
  }
});

// Start the server
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});
