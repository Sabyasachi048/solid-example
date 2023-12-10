# SOLID Principles Example

This .NET Web API project demonstrates the **SOLID** principles in action.

## SOLID Principles

In software engineering, **SOLID** is a mnemonic acronym for five design principles intended to make object-oriented designs more understandable, flexible, and maintainable.
The **SOLID** ideas are:

-   **Single-Responsibility** Principle: "There should never be more than one reason for a class to change." In other words, every class should have only one responsibility.
    e.g Each of the services in the project have a single responsibility to handle the class they were designed for.
-   **Open-Closed** Principle: "Software entities should be open for extension, but closed for modification".
    e.g. Each of the services in the project were designed as such that they open for extension and closed for modification.
-   **Liskov substitution** principle: "Functions that use pointers or references to base classes must be able to use objects of derived classes without knowing it".
    e.g. The `BaseService` follows this principle.
-   **Interface segregation** principle: "Clients should not be forced to depend upon interfaces that they do not use."
    e.g. the `AuthorService` and `UserService` follow this principle, as they do not depend on methods they do not use.
-   **Dependency inversion** principle: "Depend upon abstractions, **not** concretes."
    e.g. All of the Service classes depend upon abstractions, rather than concretes.
