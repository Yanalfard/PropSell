//---> int id
//---> string Username
//---> string Password

function SelectAdminByUsername(username)
{
    return Bjax('/api/AdminCore/SelectAdminByUsername?username=', username, 'SP');
}