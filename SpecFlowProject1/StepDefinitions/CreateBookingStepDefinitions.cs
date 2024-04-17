using HotelBooking.Core;
using HotelBooking.Infrastructure.Repositories;
using Xunit;
using HotelBooking.UnitTests;
using HotelBooking.UnitTests.Fakes;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class CreateBookingStepDefinitions
    {
        private DateTime _dateTimeStart;
        private DateTime _dateTimeEnd;
        private Booking _booking;
        private IBookingManager _bookingManager;
        private FakeRoomRepository _roomRepository;
        private FakeBookingRepository _bookingRepository;

        public CreateBookingStepDefinitions()
        {
            _roomRepository = new FakeRoomRepository();
            _bookingRepository = new FakeBookingRepository(_dateTimeStart, _dateTimeEnd);
            _bookingManager = new BookingManager(_bookingRepository, _roomRepository);
        }

        [Given("a starting date (.*)")]
        public void GivenAStartingDate(DateTime dateTimeStart)
        {
            _dateTimeStart = dateTimeStart;
        }

        [Given("an end date (.*)")]
        public void GivenAnEndDate(DateTime dateTimeEnd)
        {
            _dateTimeEnd = dateTimeEnd;
        }

        [Given("a fully occupied booking span of 10 days with a start date (.*)")]
        public void GivenOccupiedDateSpan(DateTime dateTimeStart)
        {
            _bookingRepository.Add(new Booking
            {
                StartDate = dateTimeStart,
                EndDate = dateTimeStart.AddDays(10),
                IsActive = true
            });
        }

        [When("creating a booking")]
        public void WhenCreatingABooking()
        {
            _booking = new Booking
            {
                StartDate = _dateTimeStart,
                EndDate = _dateTimeEnd,
                IsActive = true
            };

        }

        [Then("create a booking")]
        public void ThenCreateABooking()
        {
            bool isCreated = _bookingManager.CreateBooking(_booking);
            Assert.True(isCreated);
        }

        [Then("try to create a booking")]
        public void ThenTryCreateABooking()
        {
            bool isCreated;
            try
            {
                isCreated = _bookingManager.CreateBooking(_booking);
            } catch
            {
                isCreated = false;
            }
            Assert.False(isCreated);
        }
    }
}
