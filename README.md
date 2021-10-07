# Trade Risk

## C# console application to categorize trades in a bank's portfolio

A bank has a portfolio of thousands of trades and they need to be categorized. Currently, there are three categories (in order of precedence):
1. EXPIRED: Trades whose next payment date is late by more than 30 days based on a reference date which will 
be given.
2. HIGHRISK: Trades with value greater than 1,000,000 and client from Private Sector.
3. MEDIUMRISK: Trades with value greater than 1,000,000 and client from Public Sector.

#### Input
The first line of the input is the reference date. The second line contains an integer n, the number of trades in 
the portfolio. The next n lines contain 3 elements each (separated by a space). First a double that represents 
trade amount, second a string that represents the client’s sector and third a date that represents the next 
pending payment. All dates are in the format mm/dd/yyyy.

```
12/11/2020
4
2000000 Private 12/29/2025
400000 Public 07/01/2020
5000000 Public 01/02/2024
3000000 Public 10/26/2023
```
#### Output
```
HIGHRISK
EXPIRED
MEDIUMRISK
MEDIUMRISK
```
