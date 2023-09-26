Feature: MarsNotificationFeature

As a Exsting User
I would like to sign in to the Mars
So that I can mark my notification as read

Scenario: Mark the notification as read
Given I use second user json file to sign in the portal
Then I click the login button
Then I insert vaild email and password
When I click the notification dropdown list and select the see all option
Then I should see all my notification and mark first notification as read
And I should see the successfull message pop-up to the portal

