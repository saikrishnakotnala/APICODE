from flask import Flask, request, jsonify

app = Flask(__name__)

# Sample data (in-memory storage)
items = []

# Create an item
@app.route('/items', methods=['POST'])
def create_item():
    data = request.get_json()
    if 'name' in data:
        new_item = {
            'id': len(items) + 1,
            'name': data['name']
        }
        items.append(new_item)
        return jsonify(new_item), 201
    else:
        return jsonify({'error': 'Name is required'}), 400

# Read all items
@app.route('/items', methods=['GET'])
def get_all_items():
    return jsonify({'items': items})

# Read a specific item
@app.route('/items/<int:item_id>', methods=['GET'])
def get_item(item_id):
    item = next((item for item in items if item['id'] == item_id), None)
    if item:
        return jsonify(item)
    else:
        return jsonify({'error': 'Item not found'}), 404

# Update an item
@app.route('/items/<int:item_id>', methods=['PUT'])
def update_item(item_id):
    data = request.get_json()
    item = next((item for item in items if item['id'] == item_id), None)
    if item:
        item['name'] = data.get('name', item['name'])
        return jsonify(item)
    else:
        return jsonify({'error': 'Item not found'}), 404

# Delete an item
@app.route('/items/<int:item_id>', methods=['DELETE'])
def delete_item(item_id):
    global items
    items = [item for item in items if item['id'] != item_id]
    return jsonify({'message': 'Item deleted'})

if __name__ == '__main__':
    app.run(debug=True)
