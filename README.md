# seed-ui
Angular inventory UI coding sample.

Sample contains two pages. 

The first page that loads is the Seed Inventory page (the Inventory link located in the top-right navigation). It contains what I believe to be the spirit of the problem, which is to show each seed and the total number of requests for the seed. Each row is for a different seed, and if the total number of kernels requested is more than the total number of kernels available, the row is colored red.

The second page is the Seed Requests page (the Requests link located in the top-right navigation). It shows all of the individual seed requests along with the seed information corresponding to the request. If a given request cannot be fulfilled, the row for the request will be colored red. This page does not take into account the aggregate of requested kernels per seed however (like the Seed Inventory page does). So while a given request may have enough kernels to be executed upon, it is not demonstrated with the given setup whether all requests can be executed upon. This page was only included as a demonstration of a different slice of the information.
