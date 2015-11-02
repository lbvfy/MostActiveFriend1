using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// ��������� ����������� ������ �� ����� � ���������� � ���.
	/// </summary>
	public class RepostResult
	{
		/// <summary>
		/// ��������� �����������
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// ������������� ��������� ������
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// ����� ����������� �������� ������ � ������ ���������������
		/// </summary>
		public int? RepostsCount { get; set; }

		/// <summary>
		/// ����� ������� "��� ��������" � �������� ������
		/// </summary>
		public int? LikesCount { get; set; }


		#region ������

		internal static RepostResult FromJson(VkResponse response)
		{
			var result = new RepostResult();

			result.Success = response["success"];
			result.PostId = response["post_id"];
			result.RepostsCount = response["reposts_count"];
			result.LikesCount = response["likes_count"];

			return result;
		}

		#endregion

	}
}