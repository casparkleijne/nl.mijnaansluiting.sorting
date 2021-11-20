# nl.mijnaansluiting.sorting

A sorting API for alphanumeric strings

usage:

<code>IEnumerable<Entity> sorted = unsorted.OrderBy(entity => $"{entity.propertyAsString}", new AlphaNumericStringComparer());</code>
  
this is used for e.g suffixes on addresses of houses that can vary a lot.
  
note that it only handles numeric values with a max length of 16 characters.
  
  <i>note that pre-sorting makes this significant faster.</i>
              
