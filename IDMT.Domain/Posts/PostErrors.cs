using IDMT.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.Posts
{
	public static class PostErrors
	{
		public static readonly Error NotSubmitted = new(
			"Post.NotSubmitted",
			"The Post is not pending");

		public static readonly Error NotCancelled = new(
			"Post.NotCancelled",
			"The Post is not pending");
		public static readonly Error NotCompleted = new(
			"Post.NotCompleted",
			"The Post is not active");

		public static readonly Error AlreadyStarted = new(
			"Post.AlreadyStarted",
			"The Post has already started");
	}
}
