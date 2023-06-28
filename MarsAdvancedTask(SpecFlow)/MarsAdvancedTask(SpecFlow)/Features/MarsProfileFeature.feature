Feature: MarsProfileFeature

As a User
I would like to sign in to the Mars
So that I can add, edit my profile

@tag1
Scenario Outline: Add my user profile
Given I click the Sign In button
And I enter valid '<EmailAddress>', '<Password>'
Then I should be able to see my account '<UserName>' in the profile page
Then I start fill up my prfile details
And I can write '<Description>' into my description text area
And I add first '<Language1>' to my language skill
And I add second '<Language2>' to my language skill


Examples: 
| EmailAddress       | Password | UserName | Description                                   | Language1 | Language2 |
| eddie510@gmail.com | eddie123 | Eddie He | Hi Everyone, welcome to the JAZZ music show!! | English   | Chinese   |


Scenario Outline: Edit my user profile
Given I click the Sign In button
And I enter valid '<EmailAddress>', '<Password>'
Then I should be able to see my account '<UserName>' in the profile page
Then I can edit my profile user details
Then I can edit my '<Description>'

Examples: 
| EmailAddress       | Password | UserName | Description                                                                                                                                               |
| eddie510@gmail.com | eddie123 | Eddie He | I like different types of languages very much, because they each have their own charm, if you also like different types of languages, welcome to join me. |