SELECT
  firstName,
  lastName
FROM
  Customers
WHERE
  id = 1;

-- UPDATE
UPDATE Customers
SET
  firstName = 'Isak'
WHERE
  id = 2;

DELETE FROM Customers
WHERE
  id = 3