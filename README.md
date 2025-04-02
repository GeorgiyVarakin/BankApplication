# Bank Backend

## Case
Implement an ATM system

## Application Functions
- Account creation
- View the account balance
- Withdrawal of money from the account
- Account replenishment
- View the history of operations

## Features
- CLI
- The ability to select the operating mode (user, administrator)
    - when selecting a user, account data (number, PIN) should be requested
    - when choosing an administrator, the system password must be requested.
        - if the password is entered incorrectly, the system stops working.
- Error messages are displayed when attempting to perform incorrect operations.
- Data is persistently stored in a database (PostgreSQL)
- The application has a hexagonal architecture

## Libraries
- Microsoft dependency injection
- Spectre for CLI
- AspNetCore for API

---

## Api

#### Login to the admin account
```
/admin/authentication/{password}
```
Answer: true/false

#### Creating a bank account
```
/bankAccount/identification/{password}
```
Answer: _BankAccount_, if the password is suitable in length (between 10 and 64), otherwise null

__Example__:
```
{
  "accountGuid": 100000000000,
  "balance": 0
}
```

#### Log in to your bank account
```
/bankAccount/authentication/{id:long}/{password}
```
Answer: _BankAccount_, if an account with such an id exists and the password is suitable, otherwise null

#### Find out the account balance
```
/bankAccount/showBalance/{id}
```
Answer: the balance value (_long int_), if an account with this id is found, otherwise null

#### Find out your account history
```
/bankAccount/showHistory/{id}
```
Answer: A list of values of type _Log_

__Example__:
```
[
  {
    "accountId": 100000000000,
    "datetime": "01.01.2025 21:22:50",
    "balanceBeforeOperation": 0,
    "balanceAfterOperation": 12,
    "delta": 12
  },
  {
    "accountId": 100000000000,
    "datetime": "01.01.2025 21:22:51",
    "balanceBeforeOperation": 12,
    "balanceAfterOperation": 24,
    "delta": 12
  },
  {
    "accountId": 100000000000,
    "datetime": "01.01.2025 21:22:51",
    "balanceBeforeOperation": 24,
    "balanceAfterOperation": 36,
    "delta": 12
  }
]
```

#### Increase the account balance value
```
/bankAccount/addMoney/{id:long}/{delta:long}
```
Answer: returns _BankOperationAnswer_

__Example__:
```
{
  "isSuccess": true,
  "result": {
    "resultType": "Success",
    "resultMessage": "Now balance is 36"
  },
  "bankAccount": {
    "accountGuid": 100000000000,
    "balance": 36
  },
  "newLog": {
    "accountId": 100000000000,
    "datetime": "01.01.2025 21:22:51",
    "balanceBeforeOperation": 24,
    "balanceAfterOperation": 36,
    "delta": 12
  }
}
```

#### Reduce the account balance value
```
/bankAccount/withdrawMoney/{id:long}/{delta:long}
```
Answer: returns _BankOperationAnswer_

### References
#### _Bank account_
```
{
  "accountGuid": int,
  "balance": int
}
```

#### _Log_
```
{
  "accountId": int,
  "datetime": "string",
  "balanceBeforeOperation": int,
  "balanceAfterOperation": int,
  "delta": int
}
```

---

#### _Result_
```
{
  "resultType": "string",
  "resultMessage": "string"
}
```

#### _BankOperationAnswer_
```
{
  "isSuccess": true,
  "result": {
    "resultType": "string",
    "resultMessage": "string"
  },
  "bankAccount": {
    "accountGuid": int,
    "balance": int
  },
  "newLog": {
    "accountId": int,
    "datetime": "string",
    "balanceBeforeOperation": int,
    "balanceAfterOperation": int,
    "delta": int
  }
}
```
