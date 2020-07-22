﻿
function generateBlocks(count, id) {

    let div = document.getElementById(id);
    console.log(div);
    for (var i = 0; i < count; i++) {
        div.innerHTML = div.innerHTML.concat(`
        <!-- #region Model -->

        <div class="model row center">
            <div class="column">
                <header>
                    لورم ایپسوم متن ساختگی
                </header>

                <p>
                    ${i * 1000}
                </p>
                <div class="price row">
                    <img src="../Resources/Vector/real.svg" />
                    <label>1900000</label>
                </div>
            </div>

            <img src="../Resources/Raster/House.jpeg" alt="" />
        </div>

        <!-- #endregion -->
`)
    }
}

function LoadTop9() {
    for (const model of SelectLatestProperties(9)) {
        generateBlock("recent", model);
    }
}

//---> int id
//---> string Title
//---> string Description
//---> bool Valid
//---> bool ShowToFriends
//---> int UserId
//---> int CityId
//---> string Neighborhood
function generateBlock(divId, model) {

    let div = document.getElementById(divId);
    if (!model.Valid) return;

    div.innerHTML = div.innerHTML.concat(`
        <!-- #region Model -->

        <div class="model row center">
            <div class="column">
                <header>
                    ${model.Title}
                </header>

                <p>
                    ${model.Description}
                </p>
                <div class="price row">
                    <img src="../Resources/Vector/real.svg" />
                    <label>1900000</label>
                </div>
            </div>

            <img src="../Resources/Raster/House.jpeg" alt="" />
        </div>

        <!-- #endregion -->
        `)
}

//generateBlocks(9, "recent");
LoadTop9();