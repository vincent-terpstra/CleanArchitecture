# Buber Dinner API

- [Buber Dinner API](#buber-dinner-api)
    - [Auth](#auth)
        - [Register](#register)
            - [Register Request](#register-request)
            - [Register Response](#register-response)
        - [Login](#login)
            - [Login Request](#login-request)
            - [Login Response](#login-response)

## Auth

### Register

```
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "Vincent",
  "lastName": "Douglas",
  "email": "vince@gmail.com",
  "password": "Douglas1234"
}
```

#### Register Response

```json
{
  "id" : "d89c29a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Vincent",
  "lastName": "Douglas",
  "email": "vince@gmail.com",
  "token": "ejJhb...z9dqcnXoY"
}
```

### Login

```
POST {{host}}/auth/login
```

#### Login Request

```json
{
  "email": "vince@gmail.com",
  "password": "Douglas1234"
}
```

#### Login Response

```json
{
    "id": "d89c2d9a-eb3e-4075-95ff-920b55a104",
    "firstName": "vince",
    "lastName": "douglas",
    "email": "vince@gmail.com",
    "token": "ejJhb...z9dqcnXoY"
}
```