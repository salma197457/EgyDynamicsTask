export class Client {
    constructor(
       public كودالعميل: number,
       public اسمالعميل: string,
       public محلالاقامة: string, 
       public توصيف: string,
       public الوظيفة: string,
       public ادخالبواسطة: string|number,
       public اخرتعديل: string | number,
       public تاريخالادخال: Date | null,
       public اخرتعديلفي: Date | null,
       public رجلالمبيعات: string,
       public مصدرالعميل: string,
       public تصنيفالعميل: string,
       public موبايل: string,
       public تليفون1: string,
       public تليفون2: string,
       public واتس: string,
       public جنسية: string,
       public الايميل: string,
    ){}
}
