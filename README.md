# nl.mijnaansluiting.sorting

A sorting API for alphanumeric strings

usage:


<code>IEnumerable<Entity> sorted = ienumerable.OrderBy(entity => $"{entity.propertyAsString}", new AlphaNumericStringComparer());</code>
              
