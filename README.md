# BekBank Backend

---

## Run
Run the application:
In directory with BankBack.sln run this:
```
dotnet run
```
---
## Api

#### Вход в аккаунт админа
```
/admin/authentication/{password}
```
Ответ: true/false

#### Создание банковского аккаунта
```
/bankAccount/identification/{password}
```
Ответ: _BankAccount_, если пароль подходит по длине (между 10 и 64), иначе null

__Пример__:
```
{
  "accountGuid": 100000000000,
  "balance": 0
}
```

#### Вход в банковский аккаунт
```
/bankAccount/authentication/{id:long}/{password}
```
Ответ: _BankAccount_, если аккаунт с таким id существует и пароль подходит, иначе null

#### Узнать баланс аккаунта
```
/bankAccount/showBalance/{id}
```
Ответ: значение баланса (_long int_), если аккаунт с таким id найден, иначе null

#### Узнать историю аккаунта
```
/bankAccount/showHistory/{id}
```
Ответ: Лист значений типа _Log_

__Пример__:
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

#### Увеличить значение баланса аккаунта
```
/bankAccount/addMoney/{id:long}/{delta:long}
```
Ответ: возвращает _BankOperationAnswer_

__Пример__:
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

#### Уменьшить значение баланса аккаунта
```
/bankAccount/withdrawMoney/{id:long}/{delta:long}
```
Ответ: возвращает _BankOperationAnswer_

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
