using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Endpoints;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using BircheGamesApiUnitTests.Mocks.Exceptions;
using Newtonsoft.Json;

namespace BircheGamesApiUnitTests.Mocks.ThirdParty;

public class AmazonSimpleEmailServiceMock : BasicMock, IAmazonSimpleEmailService
{
  public ISimpleEmailPaginatorFactory Paginators => throw new System.NotImplementedException();

  public IClientConfig Config => throw new System.NotImplementedException();

  public Task<CloneReceiptRuleSetResponse> CloneReceiptRuleSetAsync(CloneReceiptRuleSetRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<CreateConfigurationSetResponse> CreateConfigurationSetAsync(CreateConfigurationSetRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<CreateConfigurationSetEventDestinationResponse> CreateConfigurationSetEventDestinationAsync(CreateConfigurationSetEventDestinationRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<CreateConfigurationSetTrackingOptionsResponse> CreateConfigurationSetTrackingOptionsAsync(CreateConfigurationSetTrackingOptionsRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<CreateCustomVerificationEmailTemplateResponse> CreateCustomVerificationEmailTemplateAsync(CreateCustomVerificationEmailTemplateRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<CreateReceiptFilterResponse> CreateReceiptFilterAsync(CreateReceiptFilterRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<CreateReceiptRuleResponse> CreateReceiptRuleAsync(CreateReceiptRuleRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<CreateReceiptRuleSetResponse> CreateReceiptRuleSetAsync(CreateReceiptRuleSetRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<CreateTemplateResponse> CreateTemplateAsync(CreateTemplateRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<DeleteConfigurationSetResponse> DeleteConfigurationSetAsync(DeleteConfigurationSetRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<DeleteConfigurationSetEventDestinationResponse> DeleteConfigurationSetEventDestinationAsync(DeleteConfigurationSetEventDestinationRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<DeleteConfigurationSetTrackingOptionsResponse> DeleteConfigurationSetTrackingOptionsAsync(DeleteConfigurationSetTrackingOptionsRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<DeleteCustomVerificationEmailTemplateResponse> DeleteCustomVerificationEmailTemplateAsync(DeleteCustomVerificationEmailTemplateRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<DeleteIdentityResponse> DeleteIdentityAsync(DeleteIdentityRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<DeleteIdentityPolicyResponse> DeleteIdentityPolicyAsync(DeleteIdentityPolicyRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<DeleteReceiptFilterResponse> DeleteReceiptFilterAsync(DeleteReceiptFilterRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<DeleteReceiptRuleResponse> DeleteReceiptRuleAsync(DeleteReceiptRuleRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<DeleteReceiptRuleSetResponse> DeleteReceiptRuleSetAsync(DeleteReceiptRuleSetRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<DeleteTemplateResponse> DeleteTemplateAsync(DeleteTemplateRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<DeleteVerifiedEmailAddressResponse> DeleteVerifiedEmailAddressAsync(DeleteVerifiedEmailAddressRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<DescribeActiveReceiptRuleSetResponse> DescribeActiveReceiptRuleSetAsync(DescribeActiveReceiptRuleSetRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<DescribeConfigurationSetResponse> DescribeConfigurationSetAsync(DescribeConfigurationSetRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<DescribeReceiptRuleResponse> DescribeReceiptRuleAsync(DescribeReceiptRuleRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<DescribeReceiptRuleSetResponse> DescribeReceiptRuleSetAsync(DescribeReceiptRuleSetRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Endpoint DetermineServiceOperationEndpoint(AmazonWebServiceRequest request)
  {
    throw new System.NotImplementedException();
  }

  public void Dispose()
  {
    throw new System.NotImplementedException();
  }

  public Task<GetAccountSendingEnabledResponse> GetAccountSendingEnabledAsync(GetAccountSendingEnabledRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<GetCustomVerificationEmailTemplateResponse> GetCustomVerificationEmailTemplateAsync(GetCustomVerificationEmailTemplateRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<GetIdentityDkimAttributesResponse> GetIdentityDkimAttributesAsync(GetIdentityDkimAttributesRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<GetIdentityMailFromDomainAttributesResponse> GetIdentityMailFromDomainAttributesAsync(GetIdentityMailFromDomainAttributesRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<GetIdentityNotificationAttributesResponse> GetIdentityNotificationAttributesAsync(GetIdentityNotificationAttributesRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<GetIdentityPoliciesResponse> GetIdentityPoliciesAsync(GetIdentityPoliciesRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<GetIdentityVerificationAttributesResponse> GetIdentityVerificationAttributesAsync(GetIdentityVerificationAttributesRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<GetSendQuotaResponse> GetSendQuotaAsync(CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<GetSendQuotaResponse> GetSendQuotaAsync(GetSendQuotaRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<GetSendStatisticsResponse> GetSendStatisticsAsync(CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<GetSendStatisticsResponse> GetSendStatisticsAsync(GetSendStatisticsRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<GetTemplateResponse> GetTemplateAsync(GetTemplateRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<ListConfigurationSetsResponse> ListConfigurationSetsAsync(ListConfigurationSetsRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<ListCustomVerificationEmailTemplatesResponse> ListCustomVerificationEmailTemplatesAsync(ListCustomVerificationEmailTemplatesRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<ListIdentitiesResponse> ListIdentitiesAsync(CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<ListIdentitiesResponse> ListIdentitiesAsync(ListIdentitiesRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<ListIdentityPoliciesResponse> ListIdentityPoliciesAsync(ListIdentityPoliciesRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<ListReceiptFiltersResponse> ListReceiptFiltersAsync(ListReceiptFiltersRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<ListReceiptRuleSetsResponse> ListReceiptRuleSetsAsync(ListReceiptRuleSetsRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<ListTemplatesResponse> ListTemplatesAsync(ListTemplatesRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<ListVerifiedEmailAddressesResponse> ListVerifiedEmailAddressesAsync(CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<ListVerifiedEmailAddressesResponse> ListVerifiedEmailAddressesAsync(ListVerifiedEmailAddressesRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<PutConfigurationSetDeliveryOptionsResponse> PutConfigurationSetDeliveryOptionsAsync(PutConfigurationSetDeliveryOptionsRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<PutIdentityPolicyResponse> PutIdentityPolicyAsync(PutIdentityPolicyRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<ReorderReceiptRuleSetResponse> ReorderReceiptRuleSetAsync(ReorderReceiptRuleSetRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<SendBounceResponse> SendBounceAsync(SendBounceRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<SendBulkTemplatedEmailResponse> SendBulkTemplatedEmailAsync(SendBulkTemplatedEmailRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<SendCustomVerificationEmailResponse> SendCustomVerificationEmailAsync(SendCustomVerificationEmailRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<SendEmailResponse> SendEmailAsync(SendEmailRequest request, CancellationToken cancellationToken = default)
  {
    MethodCalls.Add(new(){ MethodName = "SendEmailAsync", Arguments = new[]{ JsonConvert.SerializeObject(request), JsonConvert.SerializeObject(cancellationToken) }});

    MethodResponse response = MethodResponses["SendEmailAsync"];

    if (response == MethodResponse.THROW)
    {
      throw new IntentionalException();
    }

    if (response == MethodResponse.FAILURE)
    {
      return Task.FromResult(new SendEmailResponse()
      {
        HttpStatusCode = System.Net.HttpStatusCode.BadGateway
      });
    }

    return Task.FromResult(new SendEmailResponse()
    {
      HttpStatusCode = System.Net.HttpStatusCode.OK
    });
  }

  public Task<SendRawEmailResponse> SendRawEmailAsync(SendRawEmailRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<SendTemplatedEmailResponse> SendTemplatedEmailAsync(SendTemplatedEmailRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<SetActiveReceiptRuleSetResponse> SetActiveReceiptRuleSetAsync(SetActiveReceiptRuleSetRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<SetIdentityDkimEnabledResponse> SetIdentityDkimEnabledAsync(SetIdentityDkimEnabledRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<SetIdentityFeedbackForwardingEnabledResponse> SetIdentityFeedbackForwardingEnabledAsync(SetIdentityFeedbackForwardingEnabledRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<SetIdentityHeadersInNotificationsEnabledResponse> SetIdentityHeadersInNotificationsEnabledAsync(SetIdentityHeadersInNotificationsEnabledRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<SetIdentityMailFromDomainResponse> SetIdentityMailFromDomainAsync(SetIdentityMailFromDomainRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<SetIdentityNotificationTopicResponse> SetIdentityNotificationTopicAsync(SetIdentityNotificationTopicRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<SetReceiptRulePositionResponse> SetReceiptRulePositionAsync(SetReceiptRulePositionRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<TestRenderTemplateResponse> TestRenderTemplateAsync(TestRenderTemplateRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<UpdateAccountSendingEnabledResponse> UpdateAccountSendingEnabledAsync(UpdateAccountSendingEnabledRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<UpdateConfigurationSetEventDestinationResponse> UpdateConfigurationSetEventDestinationAsync(UpdateConfigurationSetEventDestinationRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<UpdateConfigurationSetReputationMetricsEnabledResponse> UpdateConfigurationSetReputationMetricsEnabledAsync(UpdateConfigurationSetReputationMetricsEnabledRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<UpdateConfigurationSetSendingEnabledResponse> UpdateConfigurationSetSendingEnabledAsync(UpdateConfigurationSetSendingEnabledRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<UpdateConfigurationSetTrackingOptionsResponse> UpdateConfigurationSetTrackingOptionsAsync(UpdateConfigurationSetTrackingOptionsRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<UpdateCustomVerificationEmailTemplateResponse> UpdateCustomVerificationEmailTemplateAsync(UpdateCustomVerificationEmailTemplateRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<UpdateReceiptRuleResponse> UpdateReceiptRuleAsync(UpdateReceiptRuleRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<UpdateTemplateResponse> UpdateTemplateAsync(UpdateTemplateRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<VerifyDomainDkimResponse> VerifyDomainDkimAsync(VerifyDomainDkimRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<VerifyDomainIdentityResponse> VerifyDomainIdentityAsync(VerifyDomainIdentityRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<VerifyEmailAddressResponse> VerifyEmailAddressAsync(VerifyEmailAddressRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }

  public Task<VerifyEmailIdentityResponse> VerifyEmailIdentityAsync(VerifyEmailIdentityRequest request, CancellationToken cancellationToken = default)
  {
    throw new System.NotImplementedException();
  }
}