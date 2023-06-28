Feature: MarsLoginFeature

As a Exsting User
I would like to sign in to the Mars
So that I can see my profile

@tag1
Scenario Outline: Sign In Mars with vaild credentials
Given I click the Sign In button
And I enter valid '<EmailAddress>', '<Password>'
Then I should be able to see my account '<UserName>' in the profile page

Examples: 
| EmailAddress       | Password | UserName |
| eddie510@gmail.com | eddie123 | Eddie He |


Scenario Outline: Sign In Mars with invaild email address
Given I click the Sign In button
And I enter invalid '<EmailAddress>' and vaild '<Password>'
Then Should be show the emailaddress error message

Examples: 
| EmailAddress       | Password |
| !#!#!@gmail.com    | eddie123 |
| !#!#!@gmail.com    | !@#@!    |
|                    | eddie123 |
|                    |          |

Scenario Outline: Sign In Mars with invaild password
Given I click the Sign In button
And I enter vaild '<EmailAddress>' and invaild'<Password>'
Then Should be show the password error message

Examples: 
| EmailAddress       | Password |
| eddie510@gmail.com | !@#@!    |
| eddie510@gmail.com |          |