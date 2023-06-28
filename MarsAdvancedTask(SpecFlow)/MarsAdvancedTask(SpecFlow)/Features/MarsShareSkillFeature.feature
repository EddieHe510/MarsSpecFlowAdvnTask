#Feature: MarsShareSkillFeature
#
#As a Exsting User
#I would like to sign in to the Mars
#So that I can share my skill
#
#Scenario Outline: Fill up share skill form
#Given I click the Sign In button
#And I enter valid '<EmailAddress>', '<Password>'
#Then I should be able to see my account '<UserName>' in the profile page
#Then I click the Share skill button
#Then I complated all the column '<Title>', '<SKDescription>', '<Tag1>', '<Tag2>', '<StartDate>', '<EndDate>', '<StartTime>', '<EndTime>', '<SETag1>', '<SETage2>'
#
#Examples: 
#| EmailAddress       | Password | Title     | SKDescription                                   | Tag1 | Tag2      | StartDate  | EndDate    | StartTime | EndTime | SETag1 | SETag2 |
#| eddie510@gmail.com | eddie123 | Jazz Club | Hi Everyone, welcome to the JAZZ music show!!   | Jazz | LiveHouse | 30/06/2023 | 20/12/2023 | 9:00AM    | 12:00PM | Blue   | Funk   |
