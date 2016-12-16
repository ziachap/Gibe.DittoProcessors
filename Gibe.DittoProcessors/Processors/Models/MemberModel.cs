using System;
using Our.Umbraco.Ditto;

namespace Gibe.DittoProcessors.Processors.Models
{
	public class MemberModel
	{
		[UmbracoProperty("name")]
		public string Name { get; set; }

		[UmbracoProperty("id")]
		public int Id { get; set; }

		[UmbracoProperty("umbracoMemberComments")]
		public string Comments { get; set; }

		[UmbracoProperty("umbracoMemberFailedPasswordAttempts")]
		public string FailedPasswordAttempts { get; set; }

		[UmbracoProperty("umbracoMemberApproved")]
		public string IsApproved { get; set; }

		[UmbracoProperty("umbracoMemberLockedOut")]
		public string IsLockedOut { get; set; }

		[UmbracoProperty("umbracoMemberLastLockoutDate")]
		public DateTime LastLockoutDate { get; set; }

		[UmbracoProperty("umbracoMemberLastLogin")]
		public DateTime LastLoginDate { get; set; }

		[UmbracoProperty("umbracoMemberLastPasswordChangeDate")]
		public DateTime LastPasswordChangeDate { get; set; }
	}
}