export class ClientAdd {
    constructor(
        public اسمالعميل: string, ////
        public محلالاقامة: string,////
        public توصيف: string,////
        public الوظيفة: string,////
        public ادخالبواسطة: number | string,//
        public اخرتعديل: number | string,
        public تاريخالادخال: Date | string,////
        public اخرتعديلفي: Date | null,
        public رجلالمبيعات: string,//
        public مصدرالعميل: string,//
        public تصنيفالعميل: string,//
        public موبايل: string,////
        public تليفون1: string,////
        public تليفون2: string,////
        public واتس: string,////
        public جنسية: string,////
        public الايميل: string//
    ) {}
}

