﻿const cities = JSON.parse(
    `
        [{"city":"تبريز","province":"آذربايجان شرقي"},{"city":"كندوان","province":"آذربايجان شرقي"},{"city":"بندر شرفخانه","province":"آذربايجان شرقي"},{"city":"مراغه","province":"آذربايجان شرقي"},{"city":"ميانه","province":"آذربايجان شرقي"},{"city":"شبستر","province":"آذربايجان شرقي"},{"city":"مرند","province":"آذربايجان شرقي"},{"city":"جلفا","province":"آذربايجان شرقي"},{"city":"سراب","province":"آذربايجان شرقي"},{"city":"هاديشهر","province":"آذربايجان شرقي"},{"city":"بناب","province":"آذربايجان شرقي"},{"city":"كليبر","province":"آذربايجان شرقي"},{"city":"تسوج","province":"آذربايجان شرقي"},{"city":"اهر","province":"آذربايجان شرقي"},{"city":"هريس","province":"آذربايجان شرقي"},{"city":"عجبشير","province":"آذربايجان شرقي"},{"city":"هشترود","province":"آذربايجان شرقي"},{"city":"ملكان","province":"آذربايجان شرقي"},{"city":"بستان آباد","province":"آذربايجان شرقي"},{"city":"ورزقان","province":"آذربايجان شرقي"},{"city":"اسكو","province":"آذربايجان شرقي"},{"city":"آذر شهر","province":"آذربايجان شرقي"},{"city":"قره آغاج","province":"آذربايجان شرقي"},{"city":"ممقان","province":"آذربايجان شرقي"},{"city":"صوفیان","province":"آذربايجان شرقي"},{"city":"ایلخچی","province":"آذربايجان شرقي"},{"city":"خسروشهر","province":"آذربايجان شرقي"},{"city":"باسمنج","province":"آذربايجان شرقي"},{"city":"سهند","province":"آذربايجان شرقي"},{"city":"اروميه","province":"آذربايجان غربي"},{"city":"نقده","province":"آذربايجان غربي"},{"city":"ماكو","province":"آذربايجان غربي"},{"city":"تكاب","province":"آذربايجان غربي"},{"city":"خوي","province":"آذربايجان غربي"},{"city":"مهاباد","province":"آذربايجان غربي"},{"city":"سر دشت","province":"آذربايجان غربي"},{"city":"چالدران","province":"آذربايجان غربي"},{"city":"بوكان","province":"آذربايجان غربي"},{"city":"مياندوآب","province":"آذربايجان غربي"},{"city":"سلماس","province":"آذربايجان غربي"},{"city":"شاهين دژ","province":"آذربايجان غربي"},{"city":"پيرانشهر","province":"آذربايجان غربي"},{"city":"سيه چشمه","province":"آذربايجان غربي"},{"city":"اشنويه","province":"آذربايجان غربي"},{"city":"چایپاره","province":"آذربايجان غربي"},{"city":"پلدشت","province":"آذربايجان غربي"},{"city":"شوط","province":"آذربايجان غربي"},{"city":"اردبيل","province":"اردبيل"},{"city":"سرعين","province":"اردبيل"},{"city":"بيله سوار","province":"اردبيل"},{"city":"پارس آباد","province":"اردبيل"},{"city":"خلخال","province":"اردبيل"},{"city":"مشگين شهر","province":"اردبيل"},{"city":"مغان","province":"اردبيل"},{"city":"نمين","province":"اردبيل"},{"city":"نير","province":"اردبيل"},{"city":"كوثر","province":"اردبيل"},{"city":"كيوي","province":"اردبيل"},{"city":"گرمي","province":"اردبيل"},{"city":"اصفهان","province":"اصفهان"},{"city":"فريدن","province":"اصفهان"},{"city":"فريدون شهر","province":"اصفهان"},{"city":"فلاورجان","province":"اصفهان"},{"city":"گلپايگان","province":"اصفهان"},{"city":"دهاقان","province":"اصفهان"},{"city":"نطنز","province":"اصفهان"},{"city":"نايين","province":"اصفهان"},{"city":"تيران","province":"اصفهان"},{"city":"كاشان","province":"اصفهان"},{"city":"فولاد شهر","province":"اصفهان"},{"city":"اردستان","province":"اصفهان"},{"city":"سميرم","province":"اصفهان"},{"city":"درچه","province":"اصفهان"},{"city":"کوهپایه","province":"اصفهان"},{"city":"مباركه","province":"اصفهان"},{"city":"شهرضا","province":"اصفهان"},{"city":"خميني شهر","province":"اصفهان"},{"city":"شاهين شهر","province":"اصفهان"},{"city":"نجف آباد","province":"اصفهان"},{"city":"دولت آباد","province":"اصفهان"},{"city":"زرين شهر","province":"اصفهان"},{"city":"آران و بيدگل","province":"اصفهان"},{"city":"باغ بهادران","province":"اصفهان"},{"city":"خوانسار","province":"اصفهان"},{"city":"مهردشت","province":"اصفهان"},{"city":"علويجه","province":"اصفهان"},{"city":"عسگران","province":"اصفهان"},{"city":"نهضت آباد","province":"اصفهان"},{"city":"حاجي آباد","province":"اصفهان"},{"city":"تودشک","province":"اصفهان"},{"city":"ورزنه","province":"اصفهان"},{"city":"ايلام","province":"ايلام"},{"city":"مهران","province":"ايلام"},{"city":"دهلران","province":"ايلام"},{"city":"آبدانان","province":"ايلام"},{"city":"شيروان چرداول","province":"ايلام"},{"city":"دره شهر","province":"ايلام"},{"city":"ايوان","province":"ايلام"},{"city":"سرابله","province":"ايلام"},{"city":"بوشهر","province":"بوشهر"},{"city":"تنگستان","province":"بوشهر"},{"city":"دشتستان","province":"بوشهر"},{"city":"دير","province":"بوشهر"},{"city":"ديلم","province":"بوشهر"},{"city":"كنگان","province":"بوشهر"},{"city":"گناوه","province":"بوشهر"},{"city":"ريشهر","province":"بوشهر"},{"city":"دشتي","province":"بوشهر"},{"city":"خورموج","province":"بوشهر"},{"city":"اهرم","province":"بوشهر"},{"city":"برازجان","province":"بوشهر"},{"city":"خارك","province":"بوشهر"},{"city":"جم","province":"بوشهر"},{"city":"کاکی","province":"بوشهر"},{"city":"عسلویه","province":"بوشهر"},{"city":"بردخون","province":"بوشهر"},{"city":"تهران","province":"تهران"},{"city":"ورامين","province":"تهران"},{"city":"فيروزكوه","province":"تهران"},{"city":"ري","province":"تهران"},{"city":"دماوند","province":"تهران"},{"city":"اسلامشهر","province":"تهران"},{"city":"رودهن","province":"تهران"},{"city":"لواسان","province":"تهران"},{"city":"بومهن","province":"تهران"},{"city":"تجريش","province":"تهران"},{"city":"فشم","province":"تهران"},{"city":"كهريزك","province":"تهران"},{"city":"پاكدشت","province":"تهران"},{"city":"چهاردانگه","province":"تهران"},{"city":"شريف آباد","province":"تهران"},{"city":"قرچك","province":"تهران"},{"city":"باقرشهر","province":"تهران"},{"city":"شهريار","province":"تهران"},{"city":"رباط كريم","province":"تهران"},{"city":"قدس","province":"تهران"},{"city":"ملارد","province":"تهران"},{"city":"شهركرد","province":"چهارمحال بختياري"},{"city":"فارسان","province":"چهارمحال بختياري"},{"city":"بروجن","province":"چهارمحال بختياري"},{"city":"چلگرد","province":"چهارمحال بختياري"},{"city":"اردل","province":"چهارمحال بختياري"},{"city":"لردگان","province":"چهارمحال بختياري"},{"city":"سامان","province":"چهارمحال بختياري"},{"city":"قائن","province":"خراسان جنوبي"},{"city":"فردوس","province":"خراسان جنوبي"},{"city":"بيرجند","province":"خراسان جنوبي"},{"city":"نهبندان","province":"خراسان جنوبي"},{"city":"سربيشه","province":"خراسان جنوبي"},{"city":"طبس مسینا","province":"خراسان جنوبي"},{"city":"قهستان","province":"خراسان جنوبي"},{"city":"درمیان","province":"خراسان جنوبي"},{"city":"مشهد","province":"خراسان رضوي"},{"city":"نيشابور","province":"خراسان رضوي"},{"city":"سبزوار","province":"خراسان رضوي"},{"city":"كاشمر","province":"خراسان رضوي"},{"city":"گناباد","province":"خراسان رضوي"},{"city":"طبس","province":"خراسان رضوي"},{"city":"تربت حيدريه","province":"خراسان رضوي"},{"city":"خواف","province":"خراسان رضوي"},{"city":"تربت جام","province":"خراسان رضوي"},{"city":"تايباد","province":"خراسان رضوي"},{"city":"قوچان","province":"خراسان رضوي"},{"city":"سرخس","province":"خراسان رضوي"},{"city":"بردسكن","province":"خراسان رضوي"},{"city":"فريمان","province":"خراسان رضوي"},{"city":"چناران","province":"خراسان رضوي"},{"city":"درگز","province":"خراسان رضوي"},{"city":"كلات","province":"خراسان رضوي"},{"city":"طرقبه","province":"خراسان رضوي"},{"city":"سر ولایت","province":"خراسان رضوي"},{"city":"بجنورد","province":"خراسان شمالي"},{"city":"اسفراين","province":"خراسان شمالي"},{"city":"جاجرم","province":"خراسان شمالي"},{"city":"شيروان","province":"خراسان شمالي"},{"city":"آشخانه","province":"خراسان شمالي"},{"city":"گرمه","province":"خراسان شمالي"},{"city":"ساروج","province":"خراسان شمالي"},{"city":"اهواز","province":"خوزستان"},{"city":"ايرانشهر","province":"خوزستان"},{"city":"شوش","province":"خوزستان"},{"city":"آبادان","province":"خوزستان"},{"city":"خرمشهر","province":"خوزستان"},{"city":"مسجد سليمان","province":"خوزستان"},{"city":"ايذه","province":"خوزستان"},{"city":"شوشتر","province":"خوزستان"},{"city":"انديمشك","province":"خوزستان"},{"city":"سوسنگرد","province":"خوزستان"},{"city":"هويزه","province":"خوزستان"},{"city":"دزفول","province":"خوزستان"},{"city":"شادگان","province":"خوزستان"},{"city":"بندر ماهشهر","province":"خوزستان"},{"city":"بندر امام خميني","province":"خوزستان"},{"city":"اميديه","province":"خوزستان"},{"city":"بهبهان","province":"خوزستان"},{"city":"رامهرمز","province":"خوزستان"},{"city":"باغ ملك","province":"خوزستان"},{"city":"هنديجان","province":"خوزستان"},{"city":"لالي","province":"خوزستان"},{"city":"رامشیر","province":"خوزستان"},{"city":"حمیدیه","province":"خوزستان"},{"city":"دغاغله","province":"خوزستان"},{"city":"ملاثانی","province":"خوزستان"},{"city":"شادگان","province":"خوزستان"},{"city":"ویسی","province":"خوزستان"},{"city":"زنجان","province":"زنجان"},{"city":"ابهر","province":"زنجان"},{"city":"خدابنده","province":"زنجان"},{"city":"كارم","province":"زنجان"},{"city":"ماهنشان","province":"زنجان"},{"city":"خرمدره","province":"زنجان"},{"city":"ايجرود","province":"زنجان"},{"city":"زرين آباد","province":"زنجان"},{"city":"آب بر","province":"زنجان"},{"city":"قيدار","province":"زنجان"},{"city":"سمنان","province":"سمنان"},{"city":"شاهرود","province":"سمنان"},{"city":"گرمسار","province":"سمنان"},{"city":"ايوانكي","province":"سمنان"},{"city":"دامغان","province":"سمنان"},{"city":"بسطام","province":"سمنان"},{"city":"زاهدان","province":"سيستان و بلوچستان"},{"city":"چابهار","province":"سيستان و بلوچستان"},{"city":"خاش","province":"سيستان و بلوچستان"},{"city":"سراوان","province":"سيستان و بلوچستان"},{"city":"زابل","province":"سيستان و بلوچستان"},{"city":"سرباز","province":"سيستان و بلوچستان"},{"city":"نيكشهر","province":"سيستان و بلوچستان"},{"city":"ايرانشهر","province":"سيستان و بلوچستان"},{"city":"راسك","province":"سيستان و بلوچستان"},{"city":"ميرجاوه","province":"سيستان و بلوچستان"},{"city":"شيراز","province":"فارس"},{"city":"اقليد","province":"فارس"},{"city":"داراب","province":"فارس"},{"city":"فسا","province":"فارس"},{"city":"مرودشت","province":"فارس"},{"city":"خرم بيد","province":"فارس"},{"city":"آباده","province":"فارس"},{"city":"كازرون","province":"فارس"},{"city":"ممسني","province":"فارس"},{"city":"سپيدان","province":"فارس"},{"city":"لار","province":"فارس"},{"city":"فيروز آباد","province":"فارس"},{"city":"جهرم","province":"فارس"},{"city":"ني ريز","province":"فارس"},{"city":"استهبان","province":"فارس"},{"city":"لامرد","province":"فارس"},{"city":"مهر","province":"فارس"},{"city":"حاجي آباد","province":"فارس"},{"city":"نورآباد","province":"فارس"},{"city":"اردكان","province":"فارس"},{"city":"صفاشهر","province":"فارس"},{"city":"ارسنجان","province":"فارس"},{"city":"قيروكارزين","province":"فارس"},{"city":"سوريان","province":"فارس"},{"city":"فراشبند","province":"فارس"},{"city":"سروستان","province":"فارس"},{"city":"ارژن","province":"فارس"},{"city":"گويم","province":"فارس"},{"city":"داريون","province":"فارس"},{"city":"زرقان","province":"فارس"},{"city":"خان زنیان","province":"فارس"},{"city":"کوار","province":"فارس"},{"city":"ده بید","province":"فارس"},{"city":"باب انار/خفر","province":"فارس"},{"city":"بوانات","province":"فارس"},{"city":"خرامه","province":"فارس"},{"city":"خنج","province":"فارس"},{"city":"سیاخ دارنگون","province":"فارس"},{"city":"قزوين","province":"قزوين"},{"city":"تاكستان","province":"قزوين"},{"city":"آبيك","province":"قزوين"},{"city":"بوئين زهرا","province":"قزوين"},{"city":"قم","province":"قم"},{"city":"طالقا","province":"البرز"},{"city":"نظرآبا","province":"البرز"},{"city":"اشتهار","province":"البرز"},{"city":"هشتگر","province":"البرز"},{"city":"كرج","province":"البرز"},{"city":"آسار","province":"البرز"},{"city":"شهرک گلستا","province":"البرز"},{"city":"اندیش","province":"البرز"},{"city":"كر","province":"البرز"},{"city":"نظر آبا","province":"البرز"},{"city":"گوهردش","province":"البرز"},{"city":"ماهدش","province":"البرز"},{"city":"مشکین دش","province":"البرز"},{"city":"سنندج","province":"كردستان"},{"city":"ديواندره","province":"كردستان"},{"city":"بانه","province":"كردستان"},{"city":"بيجار","province":"كردستان"},{"city":"سقز","province":"كردستان"},{"city":"كامياران","province":"كردستان"},{"city":"قروه","province":"كردستان"},{"city":"مريوان","province":"كردستان"},{"city":"صلوات آباد","province":"كردستان"},{"city":"حسن آباد","province":"كردستان"},{"city":"كرمان","province":"كرمان"},{"city":"راور","province":"كرمان"},{"city":"بابك","province":"كرمان"},{"city":"انار","province":"كرمان"},{"city":"کوهبنان","province":"كرمان"},{"city":"رفسنجان","province":"كرمان"},{"city":"بافت","province":"كرمان"},{"city":"سيرجان","province":"كرمان"},{"city":"كهنوج","province":"كرمان"},{"city":"زرند","province":"كرمان"},{"city":"بم","province":"كرمان"},{"city":"جيرفت","province":"كرمان"},{"city":"بردسير","province":"كرمان"},{"city":"كرمانشاه","province":"كرمانشاه"},{"city":"اسلام آباد غرب","province":"كرمانشاه"},{"city":"سر پل ذهاب","province":"كرمانشاه"},{"city":"كنگاور","province":"كرمانشاه"},{"city":"سنقر","province":"كرمانشاه"},{"city":"قصر شيرين","province":"كرمانشاه"},{"city":"گيلان غرب","province":"كرمانشاه"},{"city":"هرسين","province":"كرمانشاه"},{"city":"صحنه","province":"كرمانشاه"},{"city":"پاوه","province":"كرمانشاه"},{"city":"جوانرود","province":"كرمانشاه"},{"city":"شاهو","province":"كرمانشاه"},{"city":"ياسوج","province":"كهكيلويه و بويراحمد"},{"city":"گچساران","province":"كهكيلويه و بويراحمد"},{"city":"دنا","province":"كهكيلويه و بويراحمد"},{"city":"دوگنبدان","province":"كهكيلويه و بويراحمد"},{"city":"سي سخت","province":"كهكيلويه و بويراحمد"},{"city":"دهدشت","province":"كهكيلويه و بويراحمد"},{"city":"ليكك","province":"كهكيلويه و بويراحمد"},{"city":"گرگان","province":"گلستان"},{"city":"آق قلا","province":"گلستان"},{"city":"گنبد كاووس","province":"گلستان"},{"city":"علي آباد كتول","province":"گلستان"},{"city":"مينو دشت","province":"گلستان"},{"city":"تركمن","province":"گلستان"},{"city":"كردكوي","province":"گلستان"},{"city":"بندر گز","province":"گلستان"},{"city":"كلاله","province":"گلستان"},{"city":"آزاد شهر","province":"گلستان"},{"city":"راميان","province":"گلستان"},{"city":"رشت","province":"گيلان"},{"city":"منجيل","province":"گيلان"},{"city":"لنگرود","province":"گيلان"},{"city":"رود سر","province":"گيلان"},{"city":"تالش","province":"گيلان"},{"city":"آستارا","province":"گيلان"},{"city":"ماسوله","province":"گيلان"},{"city":"آستانه اشرفيه","province":"گيلان"},{"city":"رودبار","province":"گيلان"},{"city":"فومن","province":"گيلان"},{"city":"صومعه سرا","province":"گيلان"},{"city":"بندرانزلي","province":"گيلان"},{"city":"كلاچاي","province":"گيلان"},{"city":"هشتپر","province":"گيلان"},{"city":"رضوان شهر","province":"گيلان"},{"city":"ماسال","province":"گيلان"},{"city":"شفت","province":"گيلان"},{"city":"سياهكل","province":"گيلان"},{"city":"املش","province":"گيلان"},{"city":"لاهیجان","province":"گيلان"},{"city":"خشک بيجار","province":"گيلان"},{"city":"خمام","province":"گيلان"},{"city":"لشت نشا","province":"گيلان"},{"city":"بندر کياشهر","province":"گيلان"},{"city":"خرم آباد","province":"لرستان"},{"city":"ماهشهر","province":"لرستان"},{"city":"دزفول","province":"لرستان"},{"city":"بروجرد","province":"لرستان"},{"city":"دورود","province":"لرستان"},{"city":"اليگودرز","province":"لرستان"},{"city":"ازنا","province":"لرستان"},{"city":"نور آباد","province":"لرستان"},{"city":"كوهدشت","province":"لرستان"},{"city":"الشتر","province":"لرستان"},{"city":"پلدختر","province":"لرستان"},{"city":"ساري","province":"مازندران"},{"city":"آمل","province":"مازندران"},{"city":"بابل","province":"مازندران"},{"city":"بابلسر","province":"مازندران"},{"city":"بهشهر","province":"مازندران"},{"city":"تنكابن","province":"مازندران"},{"city":"جويبار","province":"مازندران"},{"city":"چالوس","province":"مازندران"},{"city":"رامسر","province":"مازندران"},{"city":"سواد كوه","province":"مازندران"},{"city":"قائم شهر","province":"مازندران"},{"city":"نكا","province":"مازندران"},{"city":"نور","province":"مازندران"},{"city":"بلده","province":"مازندران"},{"city":"نوشهر","province":"مازندران"},{"city":"پل سفيد","province":"مازندران"},{"city":"محمود آباد","province":"مازندران"},{"city":"فريدون كنار","province":"مازندران"},{"city":"اراك","province":"مركزي"},{"city":"آشتيان","province":"مركزي"},{"city":"تفرش","province":"مركزي"},{"city":"خمين","province":"مركزي"},{"city":"دليجان","province":"مركزي"},{"city":"ساوه","province":"مركزي"},{"city":"سربند","province":"مركزي"},{"city":"محلات","province":"مركزي"},{"city":"شازند","province":"مركزي"},{"city":"بندرعباس","province":"هرمزگان"},{"city":"قشم","province":"هرمزگان"},{"city":"كيش","province":"هرمزگان"},{"city":"بندر لنگه","province":"هرمزگان"},{"city":"بستك","province":"هرمزگان"},{"city":"حاجي آباد","province":"هرمزگان"},{"city":"دهبارز","province":"هرمزگان"},{"city":"انگهران","province":"هرمزگان"},{"city":"ميناب","province":"هرمزگان"},{"city":"ابوموسي","province":"هرمزگان"},{"city":"بندر جاسك","province":"هرمزگان"},{"city":"تنب بزرگ","province":"هرمزگان"},{"city":"بندر خمیر","province":"هرمزگان"},{"city":"پارسیان","province":"هرمزگان"},{"city":"قشم","province":"هرمزگان"},{"city":"همدان","province":"همدان"},{"city":"ملاير","province":"همدان"},{"city":"تويسركان","province":"همدان"},{"city":"نهاوند","province":"همدان"},{"city":"كبودر اهنگ","province":"همدان"},{"city":"رزن","province":"همدان"},{"city":"اسدآباد","province":"همدان"},{"city":"بهار","province":"همدان"},{"city":"يزد","province":"يزد"},{"city":"تفت","province":"يزد"},{"city":"اردكان","province":"يزد"},{"city":"ابركوه","province":"يزد"},{"city":"ميبد","province":"يزد"},{"city":"طبس","province":"يزد"},{"city":"بافق","province":"يزد"},{"city":"مهريز","province":"يزد"},{"city":"اشكذر","province":"يزد"},{"city":"هرات","province":"يزد"},{"city":"خضرآباد","province":"يزد"},{"city":"شاهديه","province":"يزد"},{"city":"حمیدیه شهر","province":"يزد"},{"city":"سید میرزا","province":"يزد"},{"city":"زارچ","province":"يزد"}]

    `
)



function findCityByProvince(prov) {

    var ans = [];
    for (let city of cities) {

        const provincessss = city.province;

        if (provincessss == (prov))
            ans.push(city.city);
    }
    //ans = SelectCityByProvinceId(SelectProvinceByName(prov).id).Name;

    return ans;
}

const ProvinceList =
    [
        "unselected",
        "آذربايجان شرقي",
        "آذربايجان غربي",
        "اردبيل",
        "اصفهان",
        "البرز",
        "ايلام",
        "بوشهر",
        "تهران",
        "چهارمحال بختياري",
        "خراسان جنوبي",
        "خراسان رضوي",
        "خراسان شمالي",
        "خوزستان",
        "زنجان",
        "سمنان",
        "سيستان و بلوچستان",
        "فارس",
        "قزوين",
        "قم",
        "كردستان",
        "كرمان",
        "كرمانشاه",
        "كهكيلويه و بويراحمد",
        "گلستان",
        "گيلان",
        "لرستان",
        "مازندران",
        "مركزي",
        "هرمزگان",
        "همدان",
        "يزد",
    ]


//(N'آذربايجان شرقي'),
//(N'آذربايجان غربي'),
//(N'اردبيل'),
//(N'اصفهان'),
//(N'البرز'),
//(N'ايلام'),
//(N'بوشهر'),
//(N'تهران'),
//(N'چهارمحال بختياري'),
//(N'خراسان جنوبي'),
//(N'خراسان رضوي'),
//(N'خراسان شمالي'),
//(N'خوزستان'),
//(N'زنجان'),
//(N'سمنان'),
//(N'سيستان و بلوچستان'),
//(N'فارس'),
//(N'قزوين'),
//(N'قم'),
//(N'كردستان'),
//(N'كرمان'),
//(N'كرمانشاه'),
//(N'كهكيلويه و بويراحمد'),
//(N'گلستان'),
//(N'گيلان'),
//(N'لرستان'),
//(N'مازندران'),  
//(N'مركزي'),
//(N'هرمزگان'),
//(N'همدان'),
//(N'يزد');