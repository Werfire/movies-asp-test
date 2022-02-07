```mermaid
classDiagram

    class ApplicationUser{

        +Addressess

        +RefreshTokens

    }

    class Basket{

        +LastModified

    }

    class Order{

        +Description

        +CreationDate

        +Status

        +DeliveryAddress

    }

    class BasketItem{

        +CatalogItemName

        +UnitPrice

        +Quantity

        +CatalogType

    }

    class OrderItem{

        +CatalogItemName

        +UnitPrice

        +Discount

        +Quantity

    }

    class CatalogItem{

        +Name

        +Description

        +Price

        +Quantity

        +CatalogType

    }

    ApplicationUser <-- "1" Basket

    ApplicationUser <-- "0..*" Order

    Basket --> "0..*" BasketItem

    Order --> "1..*" OrderItem

    BasketItem --> CatalogItem

    OrderItem --> CatalogItem 
