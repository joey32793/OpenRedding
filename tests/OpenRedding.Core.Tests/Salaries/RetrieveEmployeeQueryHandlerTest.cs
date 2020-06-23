﻿namespace OpenRedding.Core.Tests.Salaries
{
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Moq;
    using OpenRedding.Core.Exception;
    using OpenRedding.Core.Salaries.Queries.RetrieveEmployeeSalary;
    using OpenRedding.Core.Tests.Infrastructure;
    using OpenRedding.Domain.Salaries.Dtos;
    using OpenRedding.Domain.Salaries.ViewModels;
    using OpenRedding.Infrastructure.Persistence.Data;
    using Shouldly;
    using Xunit;

    public class RetrieveEmployeeQueryHandlerTest : TestFixture
    {
        [Fact]
        public async Task GivenValidRequest_WhenEmployeeSalaryRecordExists_ReturnsDetailViewModel()
        {
            // Arrange
            var query = new RetrieveEmployeeSalaryQuery(4, TestUri);
            var handler = new RetrieveEmployeeSalaryQueryHandler(Context);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<EmployeeSalaryDetailViewModel>();
            result.Employee.ShouldNotBeNull();
            result.Employee.ShouldBeOfType<EmployeeSalaryDetailDto>();
            result.Employee!.Id.ShouldBe(4);
            result.Employee.JobTitle.ShouldNotBeNull();
            result.Employee.JobTitle.ShouldBe("Senior Software Engineer");
            result.Employee.Name.ShouldNotBeNull();
            result.Employee.Name.ShouldBe("Joey Mckenzie");
            result.OccupationalBasePayAverage.HasValue.ShouldBeTrue();
            result.OccupationalBasePayAverage!.Value.ShouldBe(95m);
            result.OccupationalBenefitsAverage.HasValue.ShouldBeTrue();
            result.OccupationalBenefitsAverage!.Value.ShouldBe(100m);
            result.OccupationalTotalPayAverage.HasValue.ShouldBeTrue();
            result.OccupationalTotalPayAverage!.Value.ShouldBe(150m);
        }

        [Fact]
        public async Task GivenValidRequest_WhenEmployeeSalaryRecordDoesNotExist_ThrowsNotFoundOpenReddingException()
        {
            // Arrange
            var query = new RetrieveEmployeeSalaryQuery(44, TestUri);
            var handler = new RetrieveEmployeeSalaryQueryHandler(Context);

            // Act
            var result = await Should.ThrowAsync<OpenReddingApiException>(async () => await handler.Handle(query, CancellationToken.None));

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<OpenReddingApiException>();
            result.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }
    }
}
