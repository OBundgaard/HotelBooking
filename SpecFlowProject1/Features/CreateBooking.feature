Feature: CreateBooking

@mytag
Scenario: Create an invalid Booking
    Given a starting date 2024-06-10 10:10:10
    And an end date 2024-05-10 10:10:10
    When creating a booking
    Then try to create a booking

@mytag
Scenario: Create a Booking starting before today's date and ending before today's date
    Given a starting date 2024-01-01 10:10:10
    And an end date 2024-02-01 10:10:10
    When creating a booking
    Then try to create a booking

@mytag
Scenario: Create a Booking starting after today's date and ending after today's date
    Given a starting date 2024-04-10 10:10:10
    And an end date 2024-05-10 10:10:10
    When creating a booking
    Then create a booking

@mytag
Scenario: Create a Booking starting before today's date and ending after today's date
    Given a starting date 2024-01-01 10:10:10
    And an end date 2024-11-08 10:10:10
    When creating a booking
    Then try to create a booking

@mytag
Scenario: Create a Booking starting before today's date and ending on fully occupied date span
    Given a starting date 2024-01-01 10:10:10
    And an end date 2024-05-10 10:10:10
    And a fully occupied booking span of 10 days with a start date 2024-02-10 10:10:10
    When creating a booking
    Then try to create a booking

@mytag
Scenario: Create a Booking starting on fully occupied date span and ending after today's date
    Given a starting date 2024-03-10 10:10:10
    And an end date 2024-12-10 10:10:10
    And a fully occupied booking span of 10 days with a start date 2024-02-10 10:10:10
    When creating a booking
    Then try to create a booking

@mytag
Scenario: Create a Booking starting on fully occupied date span and ending on fully occupied date span
    Given a starting date 2024-03-10 10:10:10
    And an end date 2024-05-10 10:10:10
    And a fully occupied booking span of 10 days with a start date 2024-02-10 10:10:10
    When creating a booking
    Then try to create a booking