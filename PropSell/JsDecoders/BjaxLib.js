
//.........................██████╗░░░░░░██╗░█████╗░██╗░░██╗
//.........................██╔══██╗░░░░░██║██╔══██╗╚██╗██╔╝
//.........................██████╦╝░░░░░██║███████║░╚███╔╝░
//.........................██╔══██╗██╗░░██║██╔══██║░██╔██╗░
//.........................██████╦╝╚█████╔╝██║░░██║██╔╝╚██╗
//.........................╚═════╝░░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝

//TODO: Import bootstrap to your project;;
var returner;

const APIUrl = '';

function Bjax(url, input, methodType)
{
    if (methodType === 'SP') //Short POST
        $.ajax(
            {
                url: APIUrl + url + input,
                method: 'Post',
                contentType: 'application/json',
                dataType: 'json',
                async: false,
                success: function (data)
                {
                    returner = data;
                },
                error: function ()
                {
                    returner = false;
                }
            });
    else if (methodType === 'LP') //Long POST
        $.ajax(
            {
                url: APIUrl + url,
                data: JSON.stringify(input),
                method: 'Post',
                contentType: 'application/json',
                dataType: 'json',
                async: false,
                success: function (data)
                {
                    returner = data;
                },
                error: function ()
                {
                    returner = false;
                }
            });
    else if (methodType === 'G')//GET
        $.ajax(
            {
                url: APIUrl + url,
                method: 'Get',
                contentType: 'application/json',
                dataType: 'json',
                async: false,
                success: function (data)
                {
                    returner = data;
                },
                error: function ()
                {
                    returner = false;
                }
            });
    return returner;
}