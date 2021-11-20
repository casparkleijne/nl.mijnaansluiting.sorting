# nl.mijnaansluiting.sorting

A sorting API for alphanumeric strings

usage:


<code>IEnumerable<Entity> sorted = unsorted.OrderBy(entity => $"{entity.propertyAsString}", new AlphaNumericStringComparer());</code>
              
