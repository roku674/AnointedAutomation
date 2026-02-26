# AnointedAutomation.Enums

Shared enumerations for AnointedAutomation packages.

## Overview

This package contains all shared enum definitions used across the AnointedAutomation ecosystem. By centralizing enums in a single package, we ensure consistency and avoid duplication across dependent packages.

## Enums

### PaymentType
Defines supported payment methods.
- `None` (0)
- `PayPalToken` (1)
- `MasterCard` (2)
- `Visa` (3)
- `ACH` (4)

### MessageType
Defines log message severity levels.
- `Info` (0)
- `Warning` (1)
- `Error` (2)
- `Debug` (3)

## Usage

```csharp
using AnointedAutomation.Enums;

var paymentMethod = PaymentType.Visa;
var logLevel = MessageType.Info;
```

## License

MIT License - Copyright © 2023 Anointed Automation, LLC

Created by Alexander Fields - https://www.alexanderfields.me
