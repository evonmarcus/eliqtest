# TollFee
Calculate the toll fee for a number of passes for one vehicle.

# Example

## Request

```
http://localhost:33767/TollFee/CalculateFee?passage=2023-01-15T08:13:33&passage=2023-01-16T07:32:54&passage=2023-01-16T17:04:07
```

## Response

```
{
    "totalFee": 38
}
```

# Todo
- Make the free dates configurable runtime and stored persistently so that we can change depending on which year it is. If the request to "CalculateFee"-endpoint contains a year not yet configured, return relevant error message.
- Make sure business critical functionality is covered by unit tests.
- Fix any bugs you find.
- Feel free to refactor/comment as you see fit as if it would be real business critical code, as long as existing endpoint's interface doesn't change.

# Gothenburg congestion tax toll rules
- https://www.transportstyrelsen.se/en/road/road-tolls/Congestion-taxes-in-Stockholm-and-Goteborg/congestion-tax-in-gothenburg/hours-and-amounts-in-gothenburg/