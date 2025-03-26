# Bug Tracking System

## Aufgabe 1
Ihr Kunde möchte einen Bug-Tracking System entwickeln und hat keine Datenbank Erfahrung. Er bittet sie basieren auf dem bisherigen Excel, ein ER Modell in der dritten Normalform zu erstellen (aufzuzeichnen).


### Daten:

| BugTitle                    | BugDescription                                                                | BugReproducable | BugReportDate | ReporterFirstname | ReporterLastname | ReporterEMail               | BugStatus  | BugStatusChangeDate  | BugCategoryShort | BugCategoryLong     | BugPrioShort | BugPrioLong              | AssigneeFirstname | AssigneeLastname | AssigneeEMail             |
|-----------------------------|-------------------------------------------------------------------------------|-----------------|---------------|-------------------|------------------|-----------------------------|------------|----------------------|------------------|---------------------|--------------|--------------------------|-------------------|------------------|---------------------------|
| Login Button Not Working    | The login button does not respond when clicked.                               | true             | 2025-03-01    | Max               | Mustermann       | max.mustermann@example.com  | Open       | 2025-03-02           | UI               | User Interface      | High         | Critical                 | Anna              | Schmidt          | anna.schmidt@example.com   |
| App Crashes on Launch       | The app crashes immediately after startup on Android devices.                 | false            | 2025-03-03    | Laura             | Becker           | laura.becker@example.com    | In Progress| 2025-03-04           | Crash            | Application Crash   | High         | Major                    | Felix             | Müller           | felix.mueller@example.com  |
| Incorrect Price Displayed   | The displayed price is incorrect during checkout.                             | true           | 2025-03-04    | Karl              | Meier            | karl.meier@example.com      | Open       | 2025-03-04           | Backend          | Pricing Error       | Medium       | Moderate                 | John              | Klein            | john.klein@example.com     |
| Page Not Found (404) Error  | Clicking on a product link leads to a 404 error page.                         | true            | 2025-03-05    | Sophie            | Fischer          | sophie.fischer@example.com  | Open       | 2025-03-06           | Link             | Broken Links        | Low          | Minor                    | Michael           | König            | michael.koenig@example.com |
| Unable to Submit Form       | The form submission button is unresponsive on mobile browsers.                | true            | 2025-03-06    | Tom               | Wagner           | tom.wagner@example.com      | In Progress| 2025-03-07           | UI               | Form Issue          | High         | Critical                 | Lara              | Hoffmann         | lara.hoffmann@example.com  |
| Missing Images on Homepage  | Images are missing on the homepage in the gallery section.                    | false            | 2025-03-07    | Julia             | Lange            | julia.lange@example.com     | Open       | 2025-03-08           | UI               | Visual Glitch       | Medium       | Major                    | Thomas            | Weber            | thomas.weber@example.com   |
| Search Function Broken      | The search bar returns no results even when valid terms are entered.          | true           | 2025-03-08    | Markus            | Richter          | markus.richter@example.com  | Open       | 2025-03-09           | Backend          | Search Issue        | High         | Critical                 | Nadine            | Müller           | nadine.mueller@example.com |
| User Permissions Error      | Users are unable to access certain admin pages due to permission issues.      | true            | 2025-03-09    | Peter             | Schulz           | peter.schulz@example.com    | In Progress| 2025-03-10           | Security         | Permission Issue    | High         | Critical                 | Patrick           | Zimmermann       | patrick.zimmermann@example.com|
| Slow Loading Time           | The website takes more than 10 seconds to load on mobile devices.             | true            | 2025-03-10    | Anna              | Weber            | anna.weber@example.com      | Open       | 2025-03-11           | Performance      | Slow Performance    | Medium       | Major                    | Erik              | Schneider        | erik.schneider@example.com  |
| Error in PDF Download       | PDF download does not work after clicking the download button.                | true            | 2025-03-11    | Lukas             | Braun            | lukas.braun@example.com     | Open       | 2025-03-12           | Backend          | File Download Issue | Low          | Minor                    | Sven              | Fischer          | sven.fischer@example.com   |


**Hinweis:** Ein Bug "durchläuft" während des Prozesses verschiedene Stati. 
Reporter und Assignee sind verschiedne Personenkreise und müssen nicht in einer gemeinsamen Datenbank gespeichert sein.



