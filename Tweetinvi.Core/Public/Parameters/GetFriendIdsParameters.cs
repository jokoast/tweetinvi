﻿using System;
using Tweetinvi.Core.Public.Parameters;
using Tweetinvi.Models;

namespace Tweetinvi.Parameters
{
    /// <summary>
    /// Parameters to get a user's list of friends
    /// </summary>
    public interface IGetFriendIdsParameters : ICursorQueryParameters
    {
        /// <summary>
        /// A unique identifier of a user
        /// </summary>
        IUserIdentifier UserIdentifier { get; }
    }

    public class GetFriendIdsParameters : CursorQueryParameters, IGetFriendIdsParameters
    {
        private GetFriendIdsParameters()
        {
            MaximumNumberOfResults = 5000;
        }

        public GetFriendIdsParameters(IUserIdentifier userIdentifier) : this()
        {
            UserIdentifier = userIdentifier;
        }

        public GetFriendIdsParameters(string username) : this()
        {
            UserIdentifier = new UserIdentifier(username);
        }

        public GetFriendIdsParameters(long userId) : this()
        {
            UserIdentifier = new UserIdentifier(userId);
        }
        
        public GetFriendIdsParameters(IGetFriendIdsParameters parameters) : base(parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentException($"{nameof(parameters)} cannot be null as well as UserIdentifier");
            }
            
            UserIdentifier = parameters.UserIdentifier;
        }

        public IUserIdentifier UserIdentifier { get; }
    }
}
