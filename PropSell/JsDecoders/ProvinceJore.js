//---> int id
//---> string Name

{
    return Bjax('/api/ProvinceCore/AddProvince', province, 'LP');
}

{
    return Bjax('/api/ProvinceCore/DeleteProvince?id=', id, 'SP');
}

{
    var provinceLogId = new Array();
    provinceLogId.push(province);
    provinceLogId.push(logId);
    return Bjax('/api/ProvinceCore/UpdateProvince', provinceLogId, 'LP');
}

{
    return Bjax('/api/ProvinceCore/SelectAllProvinces', '', 'G');
}

{
    return Bjax('/api/ProvinceCore/SelectProvinceById?id=', id, 'SP');
}

{
    return Bjax('/api/ProvinceCore/SelectProvinceByName?name=', name, 'SP');
}
