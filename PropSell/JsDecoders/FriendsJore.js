//---> int id
//---> int MeId
//---> int FriendId

{
    return Bjax('/api/FriendsCore/AddFriends', friends, 'LP');
}

{
    return Bjax('/api/FriendsCore/DeleteFriends?id=', id, 'SP');
}

{
    var friendsLogId = new Array();
    friendsLogId.push(friends);
    friendsLogId.push(logId);
    return Bjax('/api/FriendsCore/UpdateFriends', friendsLogId, 'LP');
}

{
    return Bjax('/api/FriendsCore/SelectAllFriendss', '', 'G');
}

{
    return Bjax('/api/FriendsCore/SelectFriendsById?id=', id, 'SP');
}

{
    return Bjax('/api/FriendsCore/SelectFriendsByMeId?meId=', meId, 'SP');
}

{
    return Bjax('/api/FriendsCore/SelectFriendsByFriendId?friendId=', friendId, 'SP');
}
