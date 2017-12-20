Feature: Login
    I want to be able to login

Background:
  Given I reload the site



@mytag
Scenario: Login with Correct Details
    Given I have entered sanzi into the usernamefield
    And I have entered bar into the passwordfield
    When I press login
    Then i should see the welcome page

Scenario: Login with Wrong Details
    Given I have entered sanzi into the usernamefield
    And I have entered bar into the passwordfield
    When I press login
    Then i should see the welcome page

   
Scenario Outline: Successful Login with Valid Credentials
    Given User enter <username> and <password>
    When I press login
    Then i should see the welcome page
Examples:
| username   | password |
| admin@bxmail.veridone.net | Fuelsaga01! |
| nayods@boxmail.veridone.net| Fuelsaga01!|


Scenario: Login with Multiple Datas
    Given I enter the following credentials
    | Username | Password | 
    |  tunde   |akinfenwa |  
    When  I press login
    Then  i should see the welcome page