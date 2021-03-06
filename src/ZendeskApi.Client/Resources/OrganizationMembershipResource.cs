﻿using System;
using ZendeskApi.Client.Http;
using ZendeskApi.Contracts.Models;
using ZendeskApi.Contracts.Requests;
using ZendeskApi.Contracts.Responses;

namespace ZendeskApi.Client.Resources
{
    public class OrganizationMembershipResource : ZendeskResource<OrganizationMembership>, IOrganizationMembershipResource
    {
        private string _resourceUrl;
        protected override string ResourceUri
        {
            get { return _resourceUrl ?? @"/api/v2/users/{0}/organization_memberships"; }
        }

        public OrganizationMembershipResource(IRestClient client)
        {
            Client = client;
        }

        public IListResponse<OrganizationMembership> GetAllByOrganization(long organizationId)
        {
            _resourceUrl = @"/api/v2/organizations/{0}/organization_memberships";
            return GetAll<OrganizationMembershipListResponse>(organizationId);
        }

        public IListResponse<OrganizationMembership> GetAllByUser(long userId)
        {
            return GetAll<OrganizationMembershipListResponse>(userId);
        }

        public IResponse<OrganizationMembership> Post(OrganizationMembershipRequest request)
        {
            return Post<OrganizationMembershipRequest, OrganizationMembershipResponse>(request, request.Item.UserId);
        }

        [Obsolete("GetAll is deprecated, please use GetAllByUser or GetAllByOrganization instead.")]
        public IListResponse<OrganizationMembership> GetAll(long id)
        {
            return GetAll<OrganizationMembershipListResponse>(id);
        }
    }
}
