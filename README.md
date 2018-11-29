# Homework
## Homework9
    Program1为并行处理的作业
    Program为使用C#语言通过MySQL创建数据库及数据表，有关MySQL操作的选项在菜单下，关于MySQL的函数在Form1.cs下面，由于初始订单管理界面里面没有初始订单，可以经由命令行查看是否创建。
    
## Homework10
    所有操作均改为由MySQL数据库的操作，不过在其中，由于将OrderId设为主键的缘故，故因此不能修改订单号。但是修改主键之后会提示迁移数据库，在网上查询无果之后暂时放下了。
    关于订单的基本操作均在OrderService.cs下，外部的订单操作均基于此。OrderList即为之前的Order，由于Order在MySQL中为关键字，为避免可能发生的错误便修改为OrderList。OrderList、OrderDetails及OrderService均较之前有特别大的改动。
