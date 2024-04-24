@{
    Layout = "_InnerLayout";
}
@model MyViewModel

@await Html.PartialAsync("_NewMessage", Model.NewMessage)

@foreach(Message m in Model.AllMessages)
{
    <h5>@m.Writer.FirstName @m.Writer.LastName - @m.CreatedAt.ToString("MMM dd, yyy - h:mm tt")</h5>
    <p class="p-2">@m.MyMessage</p>
    <div class="ps-4">
        @foreach(Comment c in m.CommentsOnMessage)
        {
            <h6>@c.Commenter.FirstName @c.Commenter.LastName - @c.CreatedAt.ToString("MMM dd, yyy - h:mm tt")</h6>
            <p>@c.MyComment</p>
        }
        <form asp-action="CreateComment" asp-route-MessageId="@m.MessageId" method="post">
            <div class="mb-3">
                <textarea asp-for="NewComment.MyComment" class="form-control"></textarea>
                @if(ViewBag.Error == m.MessageId)
                {
                    <span asp-validation-for="NewComment.MyComment" class="text-danger"></span>
                }
            </div>
            <div class="mb-3">
                <input type="submit" value="Comment" class="btn btn-info">
            </div>
        </form>
    </div>
}