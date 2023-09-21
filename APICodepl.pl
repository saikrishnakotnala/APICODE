use Dancer2;
use JSON;

# Sample data (in-memory storage)
my @items;

# Create an item
post '/items' => sub {
    my $new_item = from_json(request->body);
    if ($new_item->{name}) {
        $new_item->{id} = scalar @items + 1;
        push @items, $new_item;
        status 201;
        return to_json($new_item);
    } else {
        status 400;
        return to_json({ error => 'Name is required' });
    }
};

# Read all items
get '/items' => sub {
    return to_json({ items => \@items });
};

# Read a specific item
get '/items/:id' => sub {
    my $itemId = param('id');
    my ($item) = grep { $_->{id} == $itemId } @items;
    if ($item) {
        return to_json($item);
    } else {
        status 404;
        return to_json({ error => 'Item not found' });
    }
};

# Update an item
put '/items/:id' => sub {
    my $itemId = param('id');
    my $updated_item = from_json(request->body);
    my ($item_index) = grep { $items[$_]->{id} == $itemId } 0..$#items;
    if (defined $item_index) {
        $items[$item_index] = { %{$items[$item_index]}, %$updated_item };
        return to_json($items[$item_index]);
    } else {
        status 404;
        return to_json({ error => 'Item not found' });
    }
};

# Delete an item
del '/items/:id' => sub {
    my $itemId = param('id');
    @items = grep { $_->{id} != $itemId } @items;
    return to_json({ message => 'Item deleted' });
};

start;
