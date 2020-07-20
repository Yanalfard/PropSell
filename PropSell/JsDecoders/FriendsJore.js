//---> int id
//---> int MeId
//---> int FriendId
function AddFriends(friends)
{
    return Bjax('/api/FriendsCore/AddFriends', friends, 'LP');
}
function DeleteFriends(id)
{
    return Bjax('/api/FriendsCore/DeleteFriends?id=', id, 'SP');
}
function UpdateFriends(friends, logId)
{
    var friendsLogId = new Array();
    friendsLogId.push(friends);
    friendsLogId.push(logId);
    return Bjax('/api/FriendsCore/UpdateFriends', friendsLogId, 'LP');
}
function SelectAllFriendss()
{
    return Bjax('/api/FriendsCore/SelectAllFriendss', '', 'G');
}
function SelectFriendsById(id)
{
    return Bjax('/api/FriendsCore/SelectFriendsById?id=', id, 'SP');
}
function SelectFriendsByMeId(meId)
{
    return Bjax('/api/FriendsCore/SelectFriendsByMeId?meId=', meId, 'SP');
}
function SelectFriendsByFriendId(friendId)
{
    return Bjax('/api/FriendsCore/SelectFriendsByFriendId?friendId=', friendId, 'SP');
}
