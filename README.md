# FirstBankOfSuncoast

The purpose of this assignment is to create a personal bank account manager. This app will let you track both savings and checking by performing transactions, such as withdrawals, deposits, and transfers. The application will also save your information in a file so you can track your account totals over time.

## Objectives

Practice control structures.
Practice data structures.
Practice working with user data.
Practice with LINQ.
Practice with Object Oriented concepts such as classes and methods.
Practice working with files.

## Requirements

Create a console app that allows a user to manage savings and checking banking transactions.

A user will make a series of transactions.

You will compute balances by examining all the transactions in the history. For instance, if a user deposits 10 to their savings, then withdraws 8 from their savings, then deposits 25 to their checking, they have three transactions to consider. Compute the checking and saving balance, using the transaction list, when needed. In this case, their savings balance is 2 and their checking balance is 25.

The transactions will be saved in a file, using a CSV format to record the data.

## Explorer Mode

- The application should store a history of transactions in a SINGLE List<Transaction>. Your task is to design the Transaction class to support both checking and savings as well as deposits and withdraws.
- The application should load past transactions from a file when it first starts.
- As a user I should be able to see the list of transactions designated savings.
- As a user I should be able to see the list of transactions designated checking.
- Never allow withdrawing more money than is available. That is, we cannot allow our checking or savings balances to go negative.
- When prompting for an amount to deposit or withdraw always ensure the amount is positive.
- The value we store in the Transaction shall be positive as well. (e.g. a Transaction that is a withdraw of 25 both inputs and records a positive 25)
- As a user I should have a menu option to make a deposit transaction for savings.
- As a user I should have a menu option to make a deposit transaction for checking.
- As a user I should have a menu option to make a withdraw transaction for savings.
- As a user I should have a menu option to make a withdraw transaction for checking.
- As a user I should have a menu option to see the balance of my savings and checking.
- The application should, after each transaction, write all the transactions to a file. This is the same file the application loads.
