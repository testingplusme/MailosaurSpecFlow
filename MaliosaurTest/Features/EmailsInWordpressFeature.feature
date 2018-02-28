Feature: EmailsInWordpressFeature

Scenario Outline: As admin, I want to confirm my mail on new WordPress page
	Given I check view of "<Subject>" mail
	When I check:
	| From                | To                               | Priority | SenderHost                |
	| hello@wordpress.com | funkyhorse.xjsbthr5@mailosaur.io | normal   | smtp3-1.bur.wordpress.com |
	Then I check correctness of images on mail:
	| Src                                                  | Alt           |
	| https://wordpress.com/i/emails/global/mark-wpcom.png | WordPress.com |
	Then I check correctness of html code


Examples: 
| Subject                  |
| Welcome to WordPress.com |
