# nl.mijnaansluiting.sorting

A sorting API for alphanumeric strings

usage:

<code>IEnumerable<Entity> sorted = unsorted.OrderBy(entity => $"{entity.propertyAsString}", new AlphaNumericStringComparer());</code>
  
this is used for e.g suffixes on addresses of houses that can vary a lot.
  
note that it only handles numeric values with a max length of 16 characters.
this solution uses padding instead of parsing to sort integer values. current local testing proves this has insignificant impact on  performance or memory.
  
 some test results:
<code>
10000 items sorted in 00:00:00.7611699 
10000 items sorted in 00:00:00.6150440  
10000 items sorted in 00:00:00.6782930
10000 items sorted in 00:00:00.7562298
10000 items sorted in 00:00:00.7927314
10000 items sorted in 00:00:00.7939269
10000 items sorted in 00:00:00.6532847
10000 items sorted in 00:00:00.5911281
10000 items sorted in 00:00:00.6708866
10000 items sorted in 00:00:00.6074409
10000 items sorted in 00:00:00.6221565
10000 items sorted in 00:00:00.6722764
10000 items sorted in 00:00:00.8406368
10000 items sorted in 00:00:00.5987612
10000 items sorted in 00:00:00.6059146
10000 items sorted in 00:00:00.6232113
10000 items sorted in 00:00:00.6942390
10000 items sorted in 00:00:00.6540156
10000 items sorted in 00:00:00.6351325
10000 items sorted in 00:00:00.6401527
10000 items sorted in 00:00:00.7387745
10000 items sorted in 00:00:00.6084280
10000 items sorted in 00:00:00.6241755
10000 items sorted in 00:00:00.6408081
10000 items sorted in 00:00:00.6167411
10000 items sorted in 00:00:00.6519947
10000 items sorted in 00:00:00.7129073
10000 items sorted in 00:00:00.7346661
10000 items sorted in 00:00:00.5929273
  </code>
  
  <i>note that pre-sorting makes this significant faster.</i>
              
