﻿SELECT * FROM OrderPro WHERE IDCus = 1;
SELECT * FROM OrderDetail WHERE IDOrder IN (SELECT ID FROM OrderPro WHERE IDCus = 1 );