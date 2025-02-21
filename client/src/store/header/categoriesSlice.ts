import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import {CategoryDto} from "../../../api/CategorySpace/CategoryService/Dtos/CategoryDto.ts";



interface CategoryState {
    categories: CategoryDto[];
    activeCategory: CategoryDto | null;
    isOpenCategoryMenu: boolean;
}

export const _categories: CategoryDto[]

    = [
    {
        "id": "1",
        "parentId": "",
        "imgUrl": null,
        "name": "Бытовая техника",
        "description": "Описание Бытовая техника",
        "level": 0,
        "fullPath": "Бытовая техника",
        "subCategories": [
            {
                "id": "c8a27818-86a1-44c7-ab31-9ef413ee68f5",
                "parentId": "",
                "imgUrl": null,
                "name": "Техника для уборки",
                "description": "Описание Техника для уборки",
                "level": 0,
                "fullPath": "Техника для уборки",
                "subCategories": [
                    {
                        "id": "e053f8c9-e125-49da-99ec-008d73a85d1a",
                        "parentId": "c8a27818-86a1-44c7-ab31-9ef413ee68f5",
                        "imgUrl": null,
                        "name": "Стиральные машины",
                        "description": "Описание Стиральные машины",
                        "level": 1,
                        "fullPath": "c8a27818-86a1-44c7-ab31-9ef413ee68f5 > Стиральные машины",
                        "subCategories": [
                            {
                                "id": "f8874917-8f43-4361-be4f-9a4e5913773a",
                                "parentId": "e053f8c9-e125-49da-99ec-008d73a85d1a",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "e053f8c9-e125-49da-99ec-008d73a85d1a > LG",
                                "subCategories": [
                                    {
                                        "id": "8db9963e-74df-4bd9-9b59-4f98d54c0110",
                                        "parentId": "f8874917-8f43-4361-be4f-9a4e5913773a",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "f8874917-8f43-4361-be4f-9a4e5913773a > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "5482af59-49f5-48d0-9944-8ecf92d38250",
                                "parentId": "e053f8c9-e125-49da-99ec-008d73a85d1a",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "e053f8c9-e125-49da-99ec-008d73a85d1a > Beko",
                                "subCategories": [
                                    {
                                        "id": "61f2957f-f350-4ff0-9cdf-88aa2f6b0993",
                                        "parentId": "5482af59-49f5-48d0-9944-8ecf92d38250",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "5482af59-49f5-48d0-9944-8ecf92d38250 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "303fc541-2dee-426e-982f-a5fff61f8b1d",
                                "parentId": "e053f8c9-e125-49da-99ec-008d73a85d1a",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "e053f8c9-e125-49da-99ec-008d73a85d1a > Siemens",
                                "subCategories": [
                                    {
                                        "id": "3f34e7c7-8fd8-4985-ae29-4d928d215366",
                                        "parentId": "303fc541-2dee-426e-982f-a5fff61f8b1d",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "303fc541-2dee-426e-982f-a5fff61f8b1d > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "89cdb025-4679-45b0-a1a4-babf1f0b903e",
                                        "parentId": "303fc541-2dee-426e-982f-a5fff61f8b1d",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "303fc541-2dee-426e-982f-a5fff61f8b1d > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "ae6a7470-79aa-48b7-a4af-791e06d89817",
                                "parentId": "e053f8c9-e125-49da-99ec-008d73a85d1a",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "e053f8c9-e125-49da-99ec-008d73a85d1a > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "d24b86e3-0768-41d7-bf36-b7698657e00d",
                                        "parentId": "ae6a7470-79aa-48b7-a4af-791e06d89817",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "ae6a7470-79aa-48b7-a4af-791e06d89817 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "5298590e-9e20-4175-932f-c5c8a06662e2",
                                "parentId": "e053f8c9-e125-49da-99ec-008d73a85d1a",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "e053f8c9-e125-49da-99ec-008d73a85d1a > Bosch",
                                "subCategories": [
                                    {
                                        "id": "332e5b20-2b84-4930-853f-4fa8a0e05495",
                                        "parentId": "5298590e-9e20-4175-932f-c5c8a06662e2",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "5298590e-9e20-4175-932f-c5c8a06662e2 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "e08044be-a025-4cab-95c0-35bc0afbfc43",
                                        "parentId": "5298590e-9e20-4175-932f-c5c8a06662e2",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "5298590e-9e20-4175-932f-c5c8a06662e2 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "0b03e9fb-aa70-4cc1-adb5-b3524bb21007",
                                "parentId": "e053f8c9-e125-49da-99ec-008d73a85d1a",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "e053f8c9-e125-49da-99ec-008d73a85d1a > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "b849cf35-0ec7-420e-a874-0c383643adc0",
                                        "parentId": "0b03e9fb-aa70-4cc1-adb5-b3524bb21007",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "0b03e9fb-aa70-4cc1-adb5-b3524bb21007 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "bd182ecc-df3c-43d5-94f7-31be7b027ae3",
                                        "parentId": "0b03e9fb-aa70-4cc1-adb5-b3524bb21007",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "0b03e9fb-aa70-4cc1-adb5-b3524bb21007 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "db44246c-3fce-4d63-b83f-bed84c95bebf",
                                "parentId": "e053f8c9-e125-49da-99ec-008d73a85d1a",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "e053f8c9-e125-49da-99ec-008d73a85d1a > Indesit",
                                "subCategories": [
                                    {
                                        "id": "7bf26211-f40a-4201-ade1-ae434e1b07a8",
                                        "parentId": "db44246c-3fce-4d63-b83f-bed84c95bebf",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "db44246c-3fce-4d63-b83f-bed84c95bebf > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "e57874b8-f729-4da5-b3da-11ed25e71eb7",
                                        "parentId": "db44246c-3fce-4d63-b83f-bed84c95bebf",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "db44246c-3fce-4d63-b83f-bed84c95bebf > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "facf7d23-e10b-408d-a6f6-822d58ffafb6",
                                "parentId": "e053f8c9-e125-49da-99ec-008d73a85d1a",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "e053f8c9-e125-49da-99ec-008d73a85d1a > Haier",
                                "subCategories": [
                                    {
                                        "id": "b203760b-2128-4259-9915-8d709a60ddb3",
                                        "parentId": "facf7d23-e10b-408d-a6f6-822d58ffafb6",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "facf7d23-e10b-408d-a6f6-822d58ffafb6 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "c12df5db-291e-4214-a510-eaf0dd487632",
                                        "parentId": "facf7d23-e10b-408d-a6f6-822d58ffafb6",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "facf7d23-e10b-408d-a6f6-822d58ffafb6 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "6b8099c2-eeca-46f1-91b6-d83f125b7b12",
                                "parentId": "e053f8c9-e125-49da-99ec-008d73a85d1a",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "e053f8c9-e125-49da-99ec-008d73a85d1a > Samsung",
                                "subCategories": [
                                    {
                                        "id": "23a52df4-e1ff-4662-9e54-65e5d1e5cdf9",
                                        "parentId": "6b8099c2-eeca-46f1-91b6-d83f125b7b12",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "6b8099c2-eeca-46f1-91b6-d83f125b7b12 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "b9d195d2-1dd2-458a-8342-ce6b7d7cda4a",
                                        "parentId": "6b8099c2-eeca-46f1-91b6-d83f125b7b12",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "6b8099c2-eeca-46f1-91b6-d83f125b7b12 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "b35eedbd-e5e2-4bda-88be-d8e6a76e78d6",
                                "parentId": "e053f8c9-e125-49da-99ec-008d73a85d1a",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "e053f8c9-e125-49da-99ec-008d73a85d1a > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "63295c21-e38c-4aca-be48-889c878a1b45",
                                        "parentId": "b35eedbd-e5e2-4bda-88be-d8e6a76e78d6",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "b35eedbd-e5e2-4bda-88be-d8e6a76e78d6 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "e205aac0-2f0e-4298-ad23-b6e473c8a40d",
                                        "parentId": "b35eedbd-e5e2-4bda-88be-d8e6a76e78d6",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "b35eedbd-e5e2-4bda-88be-d8e6a76e78d6 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        "id": "8a67394c-8dc9-4826-ae46-0afd20880948",
                        "parentId": "c8a27818-86a1-44c7-ab31-9ef413ee68f5",
                        "imgUrl": null,
                        "name": "Духовые шкафы",
                        "description": "Описание Духовые шкафы",
                        "level": 1,
                        "fullPath": "c8a27818-86a1-44c7-ab31-9ef413ee68f5 > Духовые шкафы",
                        "subCategories": [
                            {
                                "id": "01a438e4-e97f-41f2-9a9e-feb52b1f1150",
                                "parentId": "8a67394c-8dc9-4826-ae46-0afd20880948",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "8a67394c-8dc9-4826-ae46-0afd20880948 > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "4a0c6925-d6a9-4cb6-a964-c1d3e2e9795e",
                                        "parentId": "01a438e4-e97f-41f2-9a9e-feb52b1f1150",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "01a438e4-e97f-41f2-9a9e-feb52b1f1150 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "617606c8-eeba-4539-84b5-c364d833f505",
                                "parentId": "8a67394c-8dc9-4826-ae46-0afd20880948",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "8a67394c-8dc9-4826-ae46-0afd20880948 > Indesit",
                                "subCategories": [
                                    {
                                        "id": "fafea31e-63f6-4c03-93b7-2d169a9ecab3",
                                        "parentId": "617606c8-eeba-4539-84b5-c364d833f505",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "617606c8-eeba-4539-84b5-c364d833f505 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "22a2b2b5-3497-487a-b528-f9a69cf3fe14",
                                "parentId": "8a67394c-8dc9-4826-ae46-0afd20880948",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "8a67394c-8dc9-4826-ae46-0afd20880948 > Siemens",
                                "subCategories": [
                                    {
                                        "id": "8b53def7-b993-4dc7-8ad8-a2a17204bc50",
                                        "parentId": "22a2b2b5-3497-487a-b528-f9a69cf3fe14",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "22a2b2b5-3497-487a-b528-f9a69cf3fe14 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "bd036e44-9941-4e4b-bde8-161bf2fe9d02",
                                        "parentId": "22a2b2b5-3497-487a-b528-f9a69cf3fe14",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "22a2b2b5-3497-487a-b528-f9a69cf3fe14 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "7a33a566-b8b4-4331-8698-4e36c2dc9576",
                                "parentId": "8a67394c-8dc9-4826-ae46-0afd20880948",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "8a67394c-8dc9-4826-ae46-0afd20880948 > Bosch",
                                "subCategories": [
                                    {
                                        "id": "4de4ca37-6289-4a2f-b698-b015f1f9c930",
                                        "parentId": "7a33a566-b8b4-4331-8698-4e36c2dc9576",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "7a33a566-b8b4-4331-8698-4e36c2dc9576 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "dd4e489f-8225-4458-9c5e-847902fb84a7",
                                "parentId": "8a67394c-8dc9-4826-ae46-0afd20880948",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "8a67394c-8dc9-4826-ae46-0afd20880948 > LG",
                                "subCategories": [
                                    {
                                        "id": "a1beba2f-1b7f-4437-8a8f-f33f3e334fdf",
                                        "parentId": "dd4e489f-8225-4458-9c5e-847902fb84a7",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "dd4e489f-8225-4458-9c5e-847902fb84a7 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "195789f6-be53-4b01-b9e8-b3904bc16b4a",
                                "parentId": "8a67394c-8dc9-4826-ae46-0afd20880948",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "8a67394c-8dc9-4826-ae46-0afd20880948 > Samsung",
                                "subCategories": [
                                    {
                                        "id": "06cacd5a-a996-4c70-b3b3-8c8ea71d48d8",
                                        "parentId": "195789f6-be53-4b01-b9e8-b3904bc16b4a",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "195789f6-be53-4b01-b9e8-b3904bc16b4a > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "a60de452-e833-472e-af6d-f4b006b92501",
                                        "parentId": "195789f6-be53-4b01-b9e8-b3904bc16b4a",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "195789f6-be53-4b01-b9e8-b3904bc16b4a > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "5cece2fc-0ecf-42ed-b7c9-86b6a7afe435",
                                "parentId": "8a67394c-8dc9-4826-ae46-0afd20880948",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "8a67394c-8dc9-4826-ae46-0afd20880948 > Beko",
                                "subCategories": [
                                    {
                                        "id": "1d5093f7-18a3-41c9-b867-46c18a4e4fe1",
                                        "parentId": "5cece2fc-0ecf-42ed-b7c9-86b6a7afe435",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "5cece2fc-0ecf-42ed-b7c9-86b6a7afe435 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "63bed1a8-47e5-4021-ab47-d638dd2b848b",
                                        "parentId": "5cece2fc-0ecf-42ed-b7c9-86b6a7afe435",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "5cece2fc-0ecf-42ed-b7c9-86b6a7afe435 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "4c4c1ba6-3ed1-4877-8a3e-26e1fdd73cec",
                                "parentId": "8a67394c-8dc9-4826-ae46-0afd20880948",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "8a67394c-8dc9-4826-ae46-0afd20880948 > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "8864061a-94c4-44b5-9b6d-b1a9fadc616b",
                                        "parentId": "4c4c1ba6-3ed1-4877-8a3e-26e1fdd73cec",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "4c4c1ba6-3ed1-4877-8a3e-26e1fdd73cec > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "c6794b77-afae-4d88-afdd-c97991e080af",
                                        "parentId": "4c4c1ba6-3ed1-4877-8a3e-26e1fdd73cec",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "4c4c1ba6-3ed1-4877-8a3e-26e1fdd73cec > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "cdf1509b-7a5f-4595-8731-5aadc9dcfc63",
                                "parentId": "8a67394c-8dc9-4826-ae46-0afd20880948",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "8a67394c-8dc9-4826-ae46-0afd20880948 > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "a03fdcf7-be05-4ed6-bbc4-9bb2cc099c68",
                                        "parentId": "cdf1509b-7a5f-4595-8731-5aadc9dcfc63",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "cdf1509b-7a5f-4595-8731-5aadc9dcfc63 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "2f9bcb7d-1aa4-43d9-994a-962730fe195f",
                                "parentId": "8a67394c-8dc9-4826-ae46-0afd20880948",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "8a67394c-8dc9-4826-ae46-0afd20880948 > Haier",
                                "subCategories": [
                                    {
                                        "id": "598366a1-bcd7-48b4-9ed4-993ec7f8c6c9",
                                        "parentId": "2f9bcb7d-1aa4-43d9-994a-962730fe195f",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "2f9bcb7d-1aa4-43d9-994a-962730fe195f > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "068ae10b-b0dc-4740-aa4a-7b6aec4dbe41",
                                        "parentId": "2f9bcb7d-1aa4-43d9-994a-962730fe195f",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "2f9bcb7d-1aa4-43d9-994a-962730fe195f > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        "id": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6",
                        "parentId": "c8a27818-86a1-44c7-ab31-9ef413ee68f5",
                        "imgUrl": null,
                        "name": "Посудомоечные машины",
                        "description": "Описание Посудомоечные машины",
                        "level": 1,
                        "fullPath": "c8a27818-86a1-44c7-ab31-9ef413ee68f5 > Посудомоечные машины",
                        "subCategories": [
                            {
                                "id": "9721b2f6-e5b5-4d70-bcc2-8d172e009d85",
                                "parentId": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6 > Haier",
                                "subCategories": [
                                    {
                                        "id": "57334faa-3699-42e5-934c-fd8252dbbc6f",
                                        "parentId": "9721b2f6-e5b5-4d70-bcc2-8d172e009d85",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "9721b2f6-e5b5-4d70-bcc2-8d172e009d85 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "012f5637-3124-452e-a9f3-5c80e4ad9095",
                                "parentId": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6 > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "6fb95328-62b1-4adb-bb44-425fd48ae556",
                                        "parentId": "012f5637-3124-452e-a9f3-5c80e4ad9095",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "012f5637-3124-452e-a9f3-5c80e4ad9095 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "36d60c01-3e4e-4fb2-ab91-da22ebd45ceb",
                                        "parentId": "012f5637-3124-452e-a9f3-5c80e4ad9095",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "012f5637-3124-452e-a9f3-5c80e4ad9095 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "bf073ce8-8b81-4373-b7aa-7257990408a4",
                                "parentId": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6 > LG",
                                "subCategories": [
                                    {
                                        "id": "ce54155d-6a0b-4918-9f7e-a7bb9b4bd789",
                                        "parentId": "bf073ce8-8b81-4373-b7aa-7257990408a4",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "bf073ce8-8b81-4373-b7aa-7257990408a4 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "b9add836-f3ac-47dc-b48a-d8d6bb74fee9",
                                "parentId": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6 > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "3f6b07d5-6083-4bcb-990b-03c01549dfec",
                                        "parentId": "b9add836-f3ac-47dc-b48a-d8d6bb74fee9",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "b9add836-f3ac-47dc-b48a-d8d6bb74fee9 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "c8e259af-41f2-493f-b3d0-5592b651afda",
                                        "parentId": "b9add836-f3ac-47dc-b48a-d8d6bb74fee9",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "b9add836-f3ac-47dc-b48a-d8d6bb74fee9 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "7960d0dc-f8ba-4ad9-ab60-4f92552b02fb",
                                "parentId": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6 > Bosch",
                                "subCategories": [
                                    {
                                        "id": "6c291739-8435-4c3d-825b-6be453ae6295",
                                        "parentId": "7960d0dc-f8ba-4ad9-ab60-4f92552b02fb",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "7960d0dc-f8ba-4ad9-ab60-4f92552b02fb > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "e947ce97-f601-48b8-973e-926f39cf7f2d",
                                        "parentId": "7960d0dc-f8ba-4ad9-ab60-4f92552b02fb",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "7960d0dc-f8ba-4ad9-ab60-4f92552b02fb > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "72468f35-d7b5-4074-9d83-a3fff6a69ff6",
                                "parentId": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6 > Indesit",
                                "subCategories": [
                                    {
                                        "id": "b2de4317-375e-49d1-ba37-827c78eef73d",
                                        "parentId": "72468f35-d7b5-4074-9d83-a3fff6a69ff6",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "72468f35-d7b5-4074-9d83-a3fff6a69ff6 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "dabf8915-dc6a-442f-bb06-886f13aca411",
                                        "parentId": "72468f35-d7b5-4074-9d83-a3fff6a69ff6",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "72468f35-d7b5-4074-9d83-a3fff6a69ff6 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "e5e2cd72-618a-41cc-9702-30eab655af15",
                                "parentId": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6 > Beko",
                                "subCategories": [
                                    {
                                        "id": "183faa88-95ca-41fa-822d-493d7a917a22",
                                        "parentId": "e5e2cd72-618a-41cc-9702-30eab655af15",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "e5e2cd72-618a-41cc-9702-30eab655af15 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "1f64902d-b9fc-4cd0-bc86-ef82c780d48b",
                                        "parentId": "e5e2cd72-618a-41cc-9702-30eab655af15",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "e5e2cd72-618a-41cc-9702-30eab655af15 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "57426947-e35b-4748-a92f-a883bc5e0e3b",
                                "parentId": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6 > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "9c2aaf58-92c0-4988-a35b-a7298990c1a2",
                                        "parentId": "57426947-e35b-4748-a92f-a883bc5e0e3b",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "57426947-e35b-4748-a92f-a883bc5e0e3b > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "27d365bf-041c-4d5a-8187-d92119907f17",
                                        "parentId": "57426947-e35b-4748-a92f-a883bc5e0e3b",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "57426947-e35b-4748-a92f-a883bc5e0e3b > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "26ddc6a1-0615-4b2e-9a0f-7b09e5247df8",
                                "parentId": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6 > Siemens",
                                "subCategories": [
                                    {
                                        "id": "5ff4710a-11ca-4a2f-9844-8a2d00836937",
                                        "parentId": "26ddc6a1-0615-4b2e-9a0f-7b09e5247df8",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "26ddc6a1-0615-4b2e-9a0f-7b09e5247df8 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "f08772a1-4a32-44ca-9d9a-eaf8ea156356",
                                        "parentId": "26ddc6a1-0615-4b2e-9a0f-7b09e5247df8",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "26ddc6a1-0615-4b2e-9a0f-7b09e5247df8 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "adf89571-eaa5-4d88-b64f-3fb3539198d8",
                                "parentId": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "bae35bbc-a54a-45f5-b32e-0fb8a8a5d8e6 > Samsung",
                                "subCategories": [
                                    {
                                        "id": "3ba2984b-35b5-44e4-897c-ac285ad42a5c",
                                        "parentId": "adf89571-eaa5-4d88-b64f-3fb3539198d8",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "adf89571-eaa5-4d88-b64f-3fb3539198d8 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        "id": "25acf37d-61b4-4b53-9ec1-ba94086a0820",
                        "parentId": "c8a27818-86a1-44c7-ab31-9ef413ee68f5",
                        "imgUrl": null,
                        "name": "Холодильники",
                        "description": "Описание Холодильники",
                        "level": 1,
                        "fullPath": "c8a27818-86a1-44c7-ab31-9ef413ee68f5 > Холодильники",
                        "subCategories": [
                            {
                                "id": "6c9667cb-daae-4fb1-90dd-d3fcab3d6cb1",
                                "parentId": "25acf37d-61b4-4b53-9ec1-ba94086a0820",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "25acf37d-61b4-4b53-9ec1-ba94086a0820 > LG",
                                "subCategories": [
                                    {
                                        "id": "708754a8-ad5e-4608-981a-8aba88311091",
                                        "parentId": "6c9667cb-daae-4fb1-90dd-d3fcab3d6cb1",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "6c9667cb-daae-4fb1-90dd-d3fcab3d6cb1 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "8ef85bdd-3a65-4ff9-af54-b39b70ed8ded",
                                        "parentId": "6c9667cb-daae-4fb1-90dd-d3fcab3d6cb1",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "6c9667cb-daae-4fb1-90dd-d3fcab3d6cb1 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "e4d8ccc2-d519-4209-be6c-9c1bdb5f9fd8",
                                "parentId": "25acf37d-61b4-4b53-9ec1-ba94086a0820",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "25acf37d-61b4-4b53-9ec1-ba94086a0820 > Indesit",
                                "subCategories": [
                                    {
                                        "id": "e30f9130-b2c2-4499-bf9a-6e1eee7329d4",
                                        "parentId": "e4d8ccc2-d519-4209-be6c-9c1bdb5f9fd8",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "e4d8ccc2-d519-4209-be6c-9c1bdb5f9fd8 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "3cb0cee3-0302-497a-a27a-998fa4395b80",
                                        "parentId": "e4d8ccc2-d519-4209-be6c-9c1bdb5f9fd8",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "e4d8ccc2-d519-4209-be6c-9c1bdb5f9fd8 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "c40cbbfe-b0c6-416b-8303-291103925b92",
                                "parentId": "25acf37d-61b4-4b53-9ec1-ba94086a0820",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "25acf37d-61b4-4b53-9ec1-ba94086a0820 > Beko",
                                "subCategories": [
                                    {
                                        "id": "aedb1c2a-ae38-4ac6-8215-df0b44ab5794",
                                        "parentId": "c40cbbfe-b0c6-416b-8303-291103925b92",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "c40cbbfe-b0c6-416b-8303-291103925b92 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "fe42e0df-e03b-4081-b6e8-7c982557f9f7",
                                "parentId": "25acf37d-61b4-4b53-9ec1-ba94086a0820",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "25acf37d-61b4-4b53-9ec1-ba94086a0820 > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "fe8b15e5-b677-49b2-8cae-9250594bd1d7",
                                        "parentId": "fe42e0df-e03b-4081-b6e8-7c982557f9f7",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "fe42e0df-e03b-4081-b6e8-7c982557f9f7 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "fb2cebd5-ddb5-404b-b963-c5802c5e3c15",
                                "parentId": "25acf37d-61b4-4b53-9ec1-ba94086a0820",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "25acf37d-61b4-4b53-9ec1-ba94086a0820 > Bosch",
                                "subCategories": [
                                    {
                                        "id": "fafdd42c-23cd-4a10-ae26-1e071bc27d8c",
                                        "parentId": "fb2cebd5-ddb5-404b-b963-c5802c5e3c15",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "fb2cebd5-ddb5-404b-b963-c5802c5e3c15 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "b74c4a9c-31e9-46df-9a4f-6f5fdc55cace",
                                        "parentId": "fb2cebd5-ddb5-404b-b963-c5802c5e3c15",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "fb2cebd5-ddb5-404b-b963-c5802c5e3c15 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "091da410-b80f-4d5a-9af8-2de609ab4f9a",
                                "parentId": "25acf37d-61b4-4b53-9ec1-ba94086a0820",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "25acf37d-61b4-4b53-9ec1-ba94086a0820 > Haier",
                                "subCategories": [
                                    {
                                        "id": "c718d071-75c1-4bba-8de3-2150b680341e",
                                        "parentId": "091da410-b80f-4d5a-9af8-2de609ab4f9a",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "091da410-b80f-4d5a-9af8-2de609ab4f9a > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "da6abe51-86df-41d8-ad0e-15b3419ca2f3",
                                        "parentId": "091da410-b80f-4d5a-9af8-2de609ab4f9a",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "091da410-b80f-4d5a-9af8-2de609ab4f9a > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "45273df7-ec8b-42b1-ba7e-775442076752",
                                "parentId": "25acf37d-61b4-4b53-9ec1-ba94086a0820",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "25acf37d-61b4-4b53-9ec1-ba94086a0820 > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "60cb83f3-b17c-4743-a4b9-a44806567ed7",
                                        "parentId": "45273df7-ec8b-42b1-ba7e-775442076752",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "45273df7-ec8b-42b1-ba7e-775442076752 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "123f760d-2ddf-4c13-8c4f-36e1acd655e0",
                                "parentId": "25acf37d-61b4-4b53-9ec1-ba94086a0820",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "25acf37d-61b4-4b53-9ec1-ba94086a0820 > Samsung",
                                "subCategories": [
                                    {
                                        "id": "ea03f6b7-eb97-49bc-8f93-fff48da817aa",
                                        "parentId": "123f760d-2ddf-4c13-8c4f-36e1acd655e0",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "123f760d-2ddf-4c13-8c4f-36e1acd655e0 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "57c5f477-201f-411c-9e17-0cc46f1a2b8e",
                                "parentId": "25acf37d-61b4-4b53-9ec1-ba94086a0820",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "25acf37d-61b4-4b53-9ec1-ba94086a0820 > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "a1b0799e-8cfd-4658-b13d-83247d243251",
                                        "parentId": "57c5f477-201f-411c-9e17-0cc46f1a2b8e",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "57c5f477-201f-411c-9e17-0cc46f1a2b8e > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "0288e992-e9c7-4142-8d59-68f42c65160c",
                                "parentId": "25acf37d-61b4-4b53-9ec1-ba94086a0820",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "25acf37d-61b4-4b53-9ec1-ba94086a0820 > Siemens",
                                "subCategories": [
                                    {
                                        "id": "a7826cbe-8597-4f0a-a1d3-95dc943f705f",
                                        "parentId": "0288e992-e9c7-4142-8d59-68f42c65160c",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "0288e992-e9c7-4142-8d59-68f42c65160c > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        "id": "b1e7a15e-165f-4dd7-b943-c26811257fed",
                        "parentId": "67f6256f-dd63-4598-9e14-b68f810d44a7",
                        "imgUrl": null,
                        "name": "Стиральные машины",
                        "description": "Описание Стиральные машины",
                        "level": 1,
                        "fullPath": "67f6256f-dd63-4598-9e14-b68f810d44a7 > Стиральные машины",
                        "subCategories": [
                            {
                                "id": "5f488007-dc47-4b2a-8823-980d36f37752",
                                "parentId": "b1e7a15e-165f-4dd7-b943-c26811257fed",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "b1e7a15e-165f-4dd7-b943-c26811257fed > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "04eab418-c08c-4f36-a432-3e73737d01eb",
                                        "parentId": "5f488007-dc47-4b2a-8823-980d36f37752",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "5f488007-dc47-4b2a-8823-980d36f37752 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "b0875347-a7c5-4371-86f7-91d4682d9a10",
                                        "parentId": "5f488007-dc47-4b2a-8823-980d36f37752",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "5f488007-dc47-4b2a-8823-980d36f37752 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "4a2173d7-b4df-4a61-a34d-ed48aaa7331c",
                                "parentId": "b1e7a15e-165f-4dd7-b943-c26811257fed",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "b1e7a15e-165f-4dd7-b943-c26811257fed > Beko",
                                "subCategories": [
                                    {
                                        "id": "91643bff-92ad-48fa-ad85-fefdd932ddf5",
                                        "parentId": "4a2173d7-b4df-4a61-a34d-ed48aaa7331c",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "4a2173d7-b4df-4a61-a34d-ed48aaa7331c > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "1250b4fd-545e-4ea6-96c3-2a7c71bf85b1",
                                "parentId": "b1e7a15e-165f-4dd7-b943-c26811257fed",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "b1e7a15e-165f-4dd7-b943-c26811257fed > Bosch",
                                "subCategories": [
                                    {
                                        "id": "e25af359-9ce7-4022-8f48-17cf1e45fde6",
                                        "parentId": "1250b4fd-545e-4ea6-96c3-2a7c71bf85b1",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "1250b4fd-545e-4ea6-96c3-2a7c71bf85b1 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "1cdefd0f-8c4f-4d2d-b63b-c4d095da36b5",
                                "parentId": "b1e7a15e-165f-4dd7-b943-c26811257fed",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "b1e7a15e-165f-4dd7-b943-c26811257fed > Haier",
                                "subCategories": [
                                    {
                                        "id": "cb3fb2ff-f624-41ed-8f59-0a21e4990dd7",
                                        "parentId": "1cdefd0f-8c4f-4d2d-b63b-c4d095da36b5",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "1cdefd0f-8c4f-4d2d-b63b-c4d095da36b5 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "cea3979e-1901-4125-8b82-011f49416de9",
                                "parentId": "b1e7a15e-165f-4dd7-b943-c26811257fed",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "b1e7a15e-165f-4dd7-b943-c26811257fed > Siemens",
                                "subCategories": [
                                    {
                                        "id": "b5cfbd33-68f0-47cb-83be-d60f86edfa59",
                                        "parentId": "cea3979e-1901-4125-8b82-011f49416de9",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "cea3979e-1901-4125-8b82-011f49416de9 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "e43f7fef-1cd4-415b-aa79-a071c3e6e0f1",
                                "parentId": "b1e7a15e-165f-4dd7-b943-c26811257fed",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "b1e7a15e-165f-4dd7-b943-c26811257fed > LG",
                                "subCategories": [
                                    {
                                        "id": "a9c336db-89f3-4129-afb8-c28e55d434fb",
                                        "parentId": "e43f7fef-1cd4-415b-aa79-a071c3e6e0f1",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "e43f7fef-1cd4-415b-aa79-a071c3e6e0f1 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "7743c748-fd8b-4c1e-9a77-5278078159c7",
                                        "parentId": "e43f7fef-1cd4-415b-aa79-a071c3e6e0f1",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "e43f7fef-1cd4-415b-aa79-a071c3e6e0f1 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "2f47946e-aff9-4f6f-96e2-2466e26000d5",
                                "parentId": "b1e7a15e-165f-4dd7-b943-c26811257fed",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "b1e7a15e-165f-4dd7-b943-c26811257fed > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "8a8bd036-23b6-4f4a-8983-10f405e64979",
                                        "parentId": "2f47946e-aff9-4f6f-96e2-2466e26000d5",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "2f47946e-aff9-4f6f-96e2-2466e26000d5 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "704a72dd-d4ca-4b82-bd47-71b29c693d39",
                                        "parentId": "2f47946e-aff9-4f6f-96e2-2466e26000d5",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "2f47946e-aff9-4f6f-96e2-2466e26000d5 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "488c8da4-b8e5-45c3-b981-0c517c432ce9",
                                "parentId": "b1e7a15e-165f-4dd7-b943-c26811257fed",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "b1e7a15e-165f-4dd7-b943-c26811257fed > Samsung",
                                "subCategories": [
                                    {
                                        "id": "04324d6c-107e-478a-9ca3-1d24cf47f064",
                                        "parentId": "488c8da4-b8e5-45c3-b981-0c517c432ce9",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "488c8da4-b8e5-45c3-b981-0c517c432ce9 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "439b129e-73be-4406-bc7e-c6016b55671d",
                                        "parentId": "488c8da4-b8e5-45c3-b981-0c517c432ce9",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "488c8da4-b8e5-45c3-b981-0c517c432ce9 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "a52f3eae-40c9-40ce-9bd0-819bc7a666b5",
                                "parentId": "b1e7a15e-165f-4dd7-b943-c26811257fed",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "b1e7a15e-165f-4dd7-b943-c26811257fed > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "9995b585-afd7-4d1f-9197-91f6923632b3",
                                        "parentId": "a52f3eae-40c9-40ce-9bd0-819bc7a666b5",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "a52f3eae-40c9-40ce-9bd0-819bc7a666b5 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "38e827c8-2c61-4cb4-9a24-2afcac0aa43f",
                                "parentId": "b1e7a15e-165f-4dd7-b943-c26811257fed",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "b1e7a15e-165f-4dd7-b943-c26811257fed > Indesit",
                                "subCategories": [
                                    {
                                        "id": "e6102593-16bd-4d82-9b50-07bb22b0400f",
                                        "parentId": "38e827c8-2c61-4cb4-9a24-2afcac0aa43f",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "38e827c8-2c61-4cb4-9a24-2afcac0aa43f > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        "id": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c",
                        "parentId": "67f6256f-dd63-4598-9e14-b68f810d44a7",
                        "imgUrl": null,
                        "name": "Посудомоечные машины",
                        "description": "Описание Посудомоечные машины",
                        "level": 1,
                        "fullPath": "67f6256f-dd63-4598-9e14-b68f810d44a7 > Посудомоечные машины",
                        "subCategories": [
                            {
                                "id": "4b059da3-ae02-41fe-9d8e-a6a56091a504",
                                "parentId": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "e91715a4-6712-40fd-9aae-3bbdac5c5bbd",
                                        "parentId": "4b059da3-ae02-41fe-9d8e-a6a56091a504",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "4b059da3-ae02-41fe-9d8e-a6a56091a504 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "c5773ff2-cb33-4ebe-9e13-ca1e2e91fcdf",
                                "parentId": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c > Siemens",
                                "subCategories": [
                                    {
                                        "id": "f0972d6b-4463-4d49-b035-c2d74f978ac9",
                                        "parentId": "c5773ff2-cb33-4ebe-9e13-ca1e2e91fcdf",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "c5773ff2-cb33-4ebe-9e13-ca1e2e91fcdf > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "c915b5a3-c774-435c-8891-9472ee337ae9",
                                "parentId": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c > LG",
                                "subCategories": [
                                    {
                                        "id": "2c2096e5-f084-4eee-bff7-d5d9765a871b",
                                        "parentId": "c915b5a3-c774-435c-8891-9472ee337ae9",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "c915b5a3-c774-435c-8891-9472ee337ae9 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "e9ec7e2c-289a-44c2-9717-d83a24f5d3c1",
                                        "parentId": "c915b5a3-c774-435c-8891-9472ee337ae9",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "c915b5a3-c774-435c-8891-9472ee337ae9 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "fe89a223-3db1-4a6d-8e87-9e8c6ddb40b0",
                                "parentId": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "721e8666-db6b-47f0-965b-f5fe37824f78",
                                        "parentId": "fe89a223-3db1-4a6d-8e87-9e8c6ddb40b0",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "fe89a223-3db1-4a6d-8e87-9e8c6ddb40b0 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "963750c5-538c-4e6e-822c-ddfdf48a4931",
                                        "parentId": "fe89a223-3db1-4a6d-8e87-9e8c6ddb40b0",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "fe89a223-3db1-4a6d-8e87-9e8c6ddb40b0 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "34549be7-950f-457e-a28c-8c71443f3d94",
                                "parentId": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c > Haier",
                                "subCategories": [
                                    {
                                        "id": "e481f614-4d6e-43d1-8d37-2f05e76dad15",
                                        "parentId": "34549be7-950f-457e-a28c-8c71443f3d94",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "34549be7-950f-457e-a28c-8c71443f3d94 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "275d5425-e82c-42ca-aa5d-ead5645f6cc7",
                                "parentId": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "bc7c1d9e-63eb-4e1b-8f28-3aa19ded039d",
                                        "parentId": "275d5425-e82c-42ca-aa5d-ead5645f6cc7",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "275d5425-e82c-42ca-aa5d-ead5645f6cc7 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "62ddd57c-6221-40be-a8b6-c757aa14944d",
                                        "parentId": "275d5425-e82c-42ca-aa5d-ead5645f6cc7",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "275d5425-e82c-42ca-aa5d-ead5645f6cc7 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "fb076469-7961-452e-a84a-0b7bb5b9b34d",
                                "parentId": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c > Samsung",
                                "subCategories": [
                                    {
                                        "id": "9e4db5d6-aef4-477f-8103-acf7b09af413",
                                        "parentId": "fb076469-7961-452e-a84a-0b7bb5b9b34d",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "fb076469-7961-452e-a84a-0b7bb5b9b34d > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "7d296700-bc74-43e3-bc47-f889b2fccc68",
                                "parentId": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c > Bosch",
                                "subCategories": [
                                    {
                                        "id": "3df6a857-cf63-4925-860d-427b3ae0c44e",
                                        "parentId": "7d296700-bc74-43e3-bc47-f889b2fccc68",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "7d296700-bc74-43e3-bc47-f889b2fccc68 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "66351a1e-9abb-44c4-9838-2e8e810f16cf",
                                        "parentId": "7d296700-bc74-43e3-bc47-f889b2fccc68",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "7d296700-bc74-43e3-bc47-f889b2fccc68 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "2b92c9d8-f83c-4c6b-8246-42aece8975c0",
                                "parentId": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c > Indesit",
                                "subCategories": [
                                    {
                                        "id": "21db1392-dbe5-4a0e-9af0-a5c6db9a1e97",
                                        "parentId": "2b92c9d8-f83c-4c6b-8246-42aece8975c0",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "2b92c9d8-f83c-4c6b-8246-42aece8975c0 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "883674e4-ff9e-4159-bb91-ab4ea9db1bba",
                                        "parentId": "2b92c9d8-f83c-4c6b-8246-42aece8975c0",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "2b92c9d8-f83c-4c6b-8246-42aece8975c0 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "b011b519-eb2c-4351-bf42-b893f61b626a",
                                "parentId": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "ac129f7f-cce3-425b-a97b-d6d59a9fe68c > Beko",
                                "subCategories": [
                                    {
                                        "id": "97de4010-5cd5-49ac-84c1-8423cbb12ccd",
                                        "parentId": "b011b519-eb2c-4351-bf42-b893f61b626a",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "b011b519-eb2c-4351-bf42-b893f61b626a > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        "id": "eae65271-05bf-447a-9847-20087fb09df4",
                        "parentId": "67f6256f-dd63-4598-9e14-b68f810d44a7",
                        "imgUrl": null,
                        "name": "Холодильники",
                        "description": "Описание Холодильники",
                        "level": 1,
                        "fullPath": "67f6256f-dd63-4598-9e14-b68f810d44a7 > Холодильники",
                        "subCategories": [
                            {
                                "id": "4b9f07a9-e9fd-4f17-996f-3cb10f92a623",
                                "parentId": "eae65271-05bf-447a-9847-20087fb09df4",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "eae65271-05bf-447a-9847-20087fb09df4 > Samsung",
                                "subCategories": [
                                    {
                                        "id": "8e374cd5-039f-4f74-bd4e-99c017b76e11",
                                        "parentId": "4b9f07a9-e9fd-4f17-996f-3cb10f92a623",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "4b9f07a9-e9fd-4f17-996f-3cb10f92a623 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "d2cc3dd4-8a0f-46be-b66f-f035c1a564fd",
                                        "parentId": "4b9f07a9-e9fd-4f17-996f-3cb10f92a623",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "4b9f07a9-e9fd-4f17-996f-3cb10f92a623 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "5c00607f-52f5-4d69-94a8-810b82557416",
                                "parentId": "eae65271-05bf-447a-9847-20087fb09df4",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "eae65271-05bf-447a-9847-20087fb09df4 > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "824f1e9c-2613-4cf1-9180-b7b332ec26ce",
                                        "parentId": "5c00607f-52f5-4d69-94a8-810b82557416",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "5c00607f-52f5-4d69-94a8-810b82557416 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "e9e92991-678a-40f8-b2b2-7ed1d6c3c781",
                                "parentId": "eae65271-05bf-447a-9847-20087fb09df4",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "eae65271-05bf-447a-9847-20087fb09df4 > Haier",
                                "subCategories": [
                                    {
                                        "id": "b19e8bf5-022e-4887-9d1e-59138d054e4b",
                                        "parentId": "e9e92991-678a-40f8-b2b2-7ed1d6c3c781",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "e9e92991-678a-40f8-b2b2-7ed1d6c3c781 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "abe58c2c-fd7e-4838-8fe4-8ecfcec49ccd",
                                "parentId": "eae65271-05bf-447a-9847-20087fb09df4",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "eae65271-05bf-447a-9847-20087fb09df4 > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "6c330a50-ab37-4b3e-a520-91c6756d9022",
                                        "parentId": "abe58c2c-fd7e-4838-8fe4-8ecfcec49ccd",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "abe58c2c-fd7e-4838-8fe4-8ecfcec49ccd > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "5c481c06-5382-4ece-8bc6-9891e49a01e0",
                                        "parentId": "abe58c2c-fd7e-4838-8fe4-8ecfcec49ccd",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "abe58c2c-fd7e-4838-8fe4-8ecfcec49ccd > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "f20f0b62-2e8b-4099-a513-00d1dea045d5",
                                "parentId": "eae65271-05bf-447a-9847-20087fb09df4",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "eae65271-05bf-447a-9847-20087fb09df4 > Siemens",
                                "subCategories": [
                                    {
                                        "id": "80cee0ef-3f22-435e-9f95-c7fb8f8fd655",
                                        "parentId": "f20f0b62-2e8b-4099-a513-00d1dea045d5",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "f20f0b62-2e8b-4099-a513-00d1dea045d5 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "be78a08e-8470-47ee-b4db-6f03fb969f0e",
                                "parentId": "eae65271-05bf-447a-9847-20087fb09df4",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "eae65271-05bf-447a-9847-20087fb09df4 > Bosch",
                                "subCategories": [
                                    {
                                        "id": "6ad9c042-20f7-4e21-90fc-ae6036dfad56",
                                        "parentId": "be78a08e-8470-47ee-b4db-6f03fb969f0e",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "be78a08e-8470-47ee-b4db-6f03fb969f0e > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "16694d28-f15a-48f1-8d58-7eec6c418fb7",
                                        "parentId": "be78a08e-8470-47ee-b4db-6f03fb969f0e",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "be78a08e-8470-47ee-b4db-6f03fb969f0e > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "a5a8ef80-103f-43e1-99b7-aeddd0f1566a",
                                "parentId": "eae65271-05bf-447a-9847-20087fb09df4",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "eae65271-05bf-447a-9847-20087fb09df4 > Indesit",
                                "subCategories": [
                                    {
                                        "id": "b7675ea7-eccb-4e15-8e72-21fe24a539a9",
                                        "parentId": "a5a8ef80-103f-43e1-99b7-aeddd0f1566a",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "a5a8ef80-103f-43e1-99b7-aeddd0f1566a > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "6ea8b42f-0cb7-4965-97aa-6ff87d93c5b9",
                                "parentId": "eae65271-05bf-447a-9847-20087fb09df4",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "eae65271-05bf-447a-9847-20087fb09df4 > LG",
                                "subCategories": [
                                    {
                                        "id": "aac50f48-9fcc-480a-8c3c-4928fed36551",
                                        "parentId": "6ea8b42f-0cb7-4965-97aa-6ff87d93c5b9",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "6ea8b42f-0cb7-4965-97aa-6ff87d93c5b9 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "b529e974-4819-4d87-bae2-13079702c16c",
                                "parentId": "eae65271-05bf-447a-9847-20087fb09df4",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "eae65271-05bf-447a-9847-20087fb09df4 > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "742b4eb0-8828-45c6-b186-f41c46c283b7",
                                        "parentId": "b529e974-4819-4d87-bae2-13079702c16c",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "b529e974-4819-4d87-bae2-13079702c16c > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "208a3d50-c122-49c1-bd7c-99579feaeeee",
                                        "parentId": "b529e974-4819-4d87-bae2-13079702c16c",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "b529e974-4819-4d87-bae2-13079702c16c > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "035429c4-7bec-4666-8ca0-b88af9ee2f62",
                                "parentId": "eae65271-05bf-447a-9847-20087fb09df4",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "eae65271-05bf-447a-9847-20087fb09df4 > Beko",
                                "subCategories": [
                                    {
                                        "id": "a452e078-abf5-4046-badb-d1e86c1a3094",
                                        "parentId": "035429c4-7bec-4666-8ca0-b88af9ee2f62",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "035429c4-7bec-4666-8ca0-b88af9ee2f62 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    }
                ]
            },
            {
                "id": "67f6256f-dd63-4598-9e14-b68f810d44a7",
                "parentId": "",
                "imgUrl": null,
                "name": "Мелкая бытовая техника",
                "description": "Описание Мелкая бытовая техника",
                "level": 0,
                "fullPath": "Мелкая бытовая техника",
                "subCategories": [
                    {
                        "id": "a84177e6-b513-4c57-b073-8737c6cf3ed6",
                        "parentId": "67f6256f-dd63-4598-9e14-b68f810d44a7",
                        "imgUrl": null,
                        "name": "Духовые шкафы",
                        "description": "Описание Духовые шкафы",
                        "level": 1,
                        "fullPath": "67f6256f-dd63-4598-9e14-b68f810d44a7 > Духовые шкафы",
                        "subCategories": [
                            {
                                "id": "0303f77f-f962-4e1b-a7d3-9ee9c6fbf9ab",
                                "parentId": "a84177e6-b513-4c57-b073-8737c6cf3ed6",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "a84177e6-b513-4c57-b073-8737c6cf3ed6 > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "0fb0a601-46c7-4795-89cc-8a12e6fd7a77",
                                        "parentId": "0303f77f-f962-4e1b-a7d3-9ee9c6fbf9ab",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "0303f77f-f962-4e1b-a7d3-9ee9c6fbf9ab > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "b26efd74-bc8a-4d99-83bd-6245218feba1",
                                "parentId": "a84177e6-b513-4c57-b073-8737c6cf3ed6",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "a84177e6-b513-4c57-b073-8737c6cf3ed6 > Beko",
                                "subCategories": [
                                    {
                                        "id": "0d0078d4-5dfe-4a45-82ed-7f2dc18e4ec4",
                                        "parentId": "b26efd74-bc8a-4d99-83bd-6245218feba1",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "b26efd74-bc8a-4d99-83bd-6245218feba1 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "5fe9c425-b1fa-4a33-8aa8-43d97af3fe53",
                                        "parentId": "b26efd74-bc8a-4d99-83bd-6245218feba1",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "b26efd74-bc8a-4d99-83bd-6245218feba1 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "3ab378cb-0414-4e40-8d1b-4e1234b5e247",
                                "parentId": "a84177e6-b513-4c57-b073-8737c6cf3ed6",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "a84177e6-b513-4c57-b073-8737c6cf3ed6 > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "b4975d49-4cd3-43b9-9566-fafcd9f5c31f",
                                        "parentId": "3ab378cb-0414-4e40-8d1b-4e1234b5e247",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "3ab378cb-0414-4e40-8d1b-4e1234b5e247 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "630b3b38-16d2-4b8b-85d6-b140668c0c1d",
                                "parentId": "a84177e6-b513-4c57-b073-8737c6cf3ed6",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "a84177e6-b513-4c57-b073-8737c6cf3ed6 > LG",
                                "subCategories": [
                                    {
                                        "id": "6d35148b-35e6-4257-9e53-309b21cdae2c",
                                        "parentId": "630b3b38-16d2-4b8b-85d6-b140668c0c1d",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "630b3b38-16d2-4b8b-85d6-b140668c0c1d > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "f71580f3-2888-4e6c-a381-8e77d0f06f01",
                                "parentId": "a84177e6-b513-4c57-b073-8737c6cf3ed6",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "a84177e6-b513-4c57-b073-8737c6cf3ed6 > Indesit",
                                "subCategories": [
                                    {
                                        "id": "c9fbf8c4-ce27-4a3c-8a15-283e7b276ef9",
                                        "parentId": "f71580f3-2888-4e6c-a381-8e77d0f06f01",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "f71580f3-2888-4e6c-a381-8e77d0f06f01 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "10db0e6e-fedd-4936-a954-6c7ee81b2467",
                                "parentId": "a84177e6-b513-4c57-b073-8737c6cf3ed6",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "a84177e6-b513-4c57-b073-8737c6cf3ed6 > Bosch",
                                "subCategories": [
                                    {
                                        "id": "e7244bf4-48c4-4f87-b436-ad42be02de60",
                                        "parentId": "10db0e6e-fedd-4936-a954-6c7ee81b2467",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "10db0e6e-fedd-4936-a954-6c7ee81b2467 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "189c6243-48d2-4001-914c-1dd45560c729",
                                        "parentId": "10db0e6e-fedd-4936-a954-6c7ee81b2467",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "10db0e6e-fedd-4936-a954-6c7ee81b2467 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "ec311053-6eda-49ae-bf9b-f061c91c421b",
                                "parentId": "a84177e6-b513-4c57-b073-8737c6cf3ed6",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "a84177e6-b513-4c57-b073-8737c6cf3ed6 > Samsung",
                                "subCategories": [
                                    {
                                        "id": "6e6e8e67-43c1-44d3-a53c-defb903da0f4",
                                        "parentId": "ec311053-6eda-49ae-bf9b-f061c91c421b",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "ec311053-6eda-49ae-bf9b-f061c91c421b > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "3bbc95a2-9f23-4c2c-be1e-ae9f4162b9ad",
                                        "parentId": "ec311053-6eda-49ae-bf9b-f061c91c421b",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "ec311053-6eda-49ae-bf9b-f061c91c421b > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "24195151-b906-4f2b-9409-5c6ef5a5e4ea",
                                "parentId": "a84177e6-b513-4c57-b073-8737c6cf3ed6",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "a84177e6-b513-4c57-b073-8737c6cf3ed6 > Haier",
                                "subCategories": [
                                    {
                                        "id": "d0392ffd-594b-456d-b783-7a82f92b5aff",
                                        "parentId": "24195151-b906-4f2b-9409-5c6ef5a5e4ea",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "24195151-b906-4f2b-9409-5c6ef5a5e4ea > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "4b3ce276-78e2-482e-ba57-e203462b24c4",
                                        "parentId": "24195151-b906-4f2b-9409-5c6ef5a5e4ea",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "24195151-b906-4f2b-9409-5c6ef5a5e4ea > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "5b2e82fb-a243-45ff-a47c-677032a09512",
                                "parentId": "a84177e6-b513-4c57-b073-8737c6cf3ed6",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "a84177e6-b513-4c57-b073-8737c6cf3ed6 > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "8a04f167-37e0-4d04-8b13-061e1ed52cba",
                                        "parentId": "5b2e82fb-a243-45ff-a47c-677032a09512",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "5b2e82fb-a243-45ff-a47c-677032a09512 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "551ea392-4ec7-4c1a-84b7-587df258a9a5",
                                        "parentId": "5b2e82fb-a243-45ff-a47c-677032a09512",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "5b2e82fb-a243-45ff-a47c-677032a09512 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "dfc33e0d-de8d-466c-8398-089e8abb8d1a",
                                "parentId": "a84177e6-b513-4c57-b073-8737c6cf3ed6",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "a84177e6-b513-4c57-b073-8737c6cf3ed6 > Siemens",
                                "subCategories": [
                                    {
                                        "id": "1e80f290-0984-4410-a022-5f04dd71677c",
                                        "parentId": "dfc33e0d-de8d-466c-8398-089e8abb8d1a",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "dfc33e0d-de8d-466c-8398-089e8abb8d1a > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },

                ]
            },
            {
                "id": "efdc2b6e-0e07-4351-a26a-3971e4ed2a65",
                "parentId": "",
                "imgUrl": null,
                "name": "Крупная бытовая техника",
                "description": "Описание Крупная бытовая техника",
                "level": 0,
                "fullPath": "Крупная бытовая техника",
                "subCategories": [
                    {
                        "id": "d36a1163-c313-4818-b718-b2093c3ec6dd",
                        "parentId": "efdc2b6e-0e07-4351-a26a-3971e4ed2a65",
                        "imgUrl": null,
                        "name": "Посудомоечные машины",
                        "description": "Описание Посудомоечные машины",
                        "level": 1,
                        "fullPath": "efdc2b6e-0e07-4351-a26a-3971e4ed2a65 > Посудомоечные машины",
                        "subCategories": [
                            {
                                "id": "a13673c0-b394-4687-a30e-47a93f110d72",
                                "parentId": "d36a1163-c313-4818-b718-b2093c3ec6dd",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "d36a1163-c313-4818-b718-b2093c3ec6dd > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "956c1e5b-c6da-4d16-a51f-7cbb8208083f",
                                        "parentId": "a13673c0-b394-4687-a30e-47a93f110d72",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "a13673c0-b394-4687-a30e-47a93f110d72 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "5186d167-72f3-4f08-af87-ce0ee4c0e22f",
                                "parentId": "d36a1163-c313-4818-b718-b2093c3ec6dd",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "d36a1163-c313-4818-b718-b2093c3ec6dd > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "c5b1bd63-db36-4858-9e74-aec54133b7bb",
                                        "parentId": "5186d167-72f3-4f08-af87-ce0ee4c0e22f",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "5186d167-72f3-4f08-af87-ce0ee4c0e22f > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "5f5f8499-4ef7-4e00-a962-9e793e31e508",
                                "parentId": "d36a1163-c313-4818-b718-b2093c3ec6dd",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "d36a1163-c313-4818-b718-b2093c3ec6dd > Bosch",
                                "subCategories": [
                                    {
                                        "id": "4bbbee46-eeb7-4fe5-a924-6e092cad2938",
                                        "parentId": "5f5f8499-4ef7-4e00-a962-9e793e31e508",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "5f5f8499-4ef7-4e00-a962-9e793e31e508 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "c908fc0c-e846-4324-8dd9-b1d946e39d95",
                                "parentId": "d36a1163-c313-4818-b718-b2093c3ec6dd",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "d36a1163-c313-4818-b718-b2093c3ec6dd > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "4497b250-0cb5-42b3-b52d-dae34a53978b",
                                        "parentId": "c908fc0c-e846-4324-8dd9-b1d946e39d95",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "c908fc0c-e846-4324-8dd9-b1d946e39d95 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "e832a448-7553-4a90-b1f7-3f985709b922",
                                        "parentId": "c908fc0c-e846-4324-8dd9-b1d946e39d95",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "c908fc0c-e846-4324-8dd9-b1d946e39d95 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "e3f06603-63c0-4def-b230-5fdfef561a9e",
                                "parentId": "d36a1163-c313-4818-b718-b2093c3ec6dd",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "d36a1163-c313-4818-b718-b2093c3ec6dd > LG",
                                "subCategories": [
                                    {
                                        "id": "482fe524-7a33-4b71-8544-00f987272830",
                                        "parentId": "e3f06603-63c0-4def-b230-5fdfef561a9e",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "e3f06603-63c0-4def-b230-5fdfef561a9e > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "2ca09425-98e7-4fe1-8fcc-0a7382c6cb19",
                                "parentId": "d36a1163-c313-4818-b718-b2093c3ec6dd",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "d36a1163-c313-4818-b718-b2093c3ec6dd > Beko",
                                "subCategories": [
                                    {
                                        "id": "77f3a5a5-bdc0-4c07-a0bb-5defc09d7598",
                                        "parentId": "2ca09425-98e7-4fe1-8fcc-0a7382c6cb19",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "2ca09425-98e7-4fe1-8fcc-0a7382c6cb19 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "7187a413-9c01-4f35-b4fa-bd81c80cd620",
                                "parentId": "d36a1163-c313-4818-b718-b2093c3ec6dd",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "d36a1163-c313-4818-b718-b2093c3ec6dd > Siemens",
                                "subCategories": [
                                    {
                                        "id": "1eecf9ae-cc92-4ed1-a948-0ce2dcbc3bae",
                                        "parentId": "7187a413-9c01-4f35-b4fa-bd81c80cd620",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "7187a413-9c01-4f35-b4fa-bd81c80cd620 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "4015a65e-2b16-46ac-b6be-ba658fe40835",
                                "parentId": "d36a1163-c313-4818-b718-b2093c3ec6dd",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "d36a1163-c313-4818-b718-b2093c3ec6dd > Indesit",
                                "subCategories": [
                                    {
                                        "id": "6a0a6db8-fd11-427f-b6cd-530343efa495",
                                        "parentId": "4015a65e-2b16-46ac-b6be-ba658fe40835",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "4015a65e-2b16-46ac-b6be-ba658fe40835 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "e52974e4-a8e4-4fc2-8a6b-f107723276d8",
                                        "parentId": "4015a65e-2b16-46ac-b6be-ba658fe40835",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "4015a65e-2b16-46ac-b6be-ba658fe40835 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "ee31103b-4430-4516-a713-50874a91059e",
                                "parentId": "d36a1163-c313-4818-b718-b2093c3ec6dd",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "d36a1163-c313-4818-b718-b2093c3ec6dd > Samsung",
                                "subCategories": [
                                    {
                                        "id": "89c44d8f-7c38-480a-a1c6-ece37ce15d50",
                                        "parentId": "ee31103b-4430-4516-a713-50874a91059e",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "ee31103b-4430-4516-a713-50874a91059e > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "43a9d95c-c384-4beb-9157-c7c8eb4d010e",
                                        "parentId": "ee31103b-4430-4516-a713-50874a91059e",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "ee31103b-4430-4516-a713-50874a91059e > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "33347567-9069-4dfe-9be4-fcbc5d610bca",
                                "parentId": "d36a1163-c313-4818-b718-b2093c3ec6dd",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "d36a1163-c313-4818-b718-b2093c3ec6dd > Haier",
                                "subCategories": [
                                    {
                                        "id": "2e9f9b02-e4c5-4126-823b-e6b5de5e6a4b",
                                        "parentId": "33347567-9069-4dfe-9be4-fcbc5d610bca",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "33347567-9069-4dfe-9be4-fcbc5d610bca > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "2b976b6d-ed44-4e62-80d4-54207f1a8e63",
                                        "parentId": "33347567-9069-4dfe-9be4-fcbc5d610bca",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "33347567-9069-4dfe-9be4-fcbc5d610bca > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        "id": "109946f9-b87b-45fa-b588-6427d7a36d17",
                        "parentId": "efdc2b6e-0e07-4351-a26a-3971e4ed2a65",
                        "imgUrl": null,
                        "name": "Духовые шкафы",
                        "description": "Описание Духовые шкафы",
                        "level": 1,
                        "fullPath": "efdc2b6e-0e07-4351-a26a-3971e4ed2a65 > Духовые шкафы",
                        "subCategories": [
                            {
                                "id": "eed9f57f-d0d1-4372-afaa-520b475643d8",
                                "parentId": "109946f9-b87b-45fa-b588-6427d7a36d17",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "109946f9-b87b-45fa-b588-6427d7a36d17 > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "f521dcd5-5e36-435f-9486-df268e2b8056",
                                        "parentId": "eed9f57f-d0d1-4372-afaa-520b475643d8",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "eed9f57f-d0d1-4372-afaa-520b475643d8 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "44cda9b1-2408-4ebd-aa1f-b4a12bca03fe",
                                "parentId": "109946f9-b87b-45fa-b588-6427d7a36d17",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "109946f9-b87b-45fa-b588-6427d7a36d17 > Indesit",
                                "subCategories": [
                                    {
                                        "id": "4170fb99-62b2-4ece-8ee5-b1f977948a08",
                                        "parentId": "44cda9b1-2408-4ebd-aa1f-b4a12bca03fe",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "44cda9b1-2408-4ebd-aa1f-b4a12bca03fe > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "afa57e92-f50e-4068-89d2-e9b1db080827",
                                        "parentId": "44cda9b1-2408-4ebd-aa1f-b4a12bca03fe",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "44cda9b1-2408-4ebd-aa1f-b4a12bca03fe > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "ff66a531-a1d6-4ab9-b9dd-86d86492c850",
                                "parentId": "109946f9-b87b-45fa-b588-6427d7a36d17",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "109946f9-b87b-45fa-b588-6427d7a36d17 > Bosch",
                                "subCategories": [
                                    {
                                        "id": "cbc1f28a-e9df-4b02-b6e6-845f8a3e1d39",
                                        "parentId": "ff66a531-a1d6-4ab9-b9dd-86d86492c850",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "ff66a531-a1d6-4ab9-b9dd-86d86492c850 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "44a51023-7312-46e1-8aa7-e658e3aa4ef6",
                                        "parentId": "ff66a531-a1d6-4ab9-b9dd-86d86492c850",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "ff66a531-a1d6-4ab9-b9dd-86d86492c850 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "001e2560-b06f-4d03-959b-0e76368bc679",
                                "parentId": "109946f9-b87b-45fa-b588-6427d7a36d17",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "109946f9-b87b-45fa-b588-6427d7a36d17 > Haier",
                                "subCategories": [
                                    {
                                        "id": "9a853363-b143-4cad-a7d7-383b7c0560a7",
                                        "parentId": "001e2560-b06f-4d03-959b-0e76368bc679",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "001e2560-b06f-4d03-959b-0e76368bc679 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "3a6e32b1-5f01-4598-9cb4-b00894907d3c",
                                "parentId": "109946f9-b87b-45fa-b588-6427d7a36d17",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "109946f9-b87b-45fa-b588-6427d7a36d17 > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "d814a208-e17c-465b-942c-5066e38a4805",
                                        "parentId": "3a6e32b1-5f01-4598-9cb4-b00894907d3c",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "3a6e32b1-5f01-4598-9cb4-b00894907d3c > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "a1037a84-1547-4a3a-b053-435314dc0c51",
                                "parentId": "109946f9-b87b-45fa-b588-6427d7a36d17",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "109946f9-b87b-45fa-b588-6427d7a36d17 > Siemens",
                                "subCategories": [
                                    {
                                        "id": "f35ffffb-2142-41a8-b2ea-20bd05a8a342",
                                        "parentId": "a1037a84-1547-4a3a-b053-435314dc0c51",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "a1037a84-1547-4a3a-b053-435314dc0c51 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "639d00dc-cd11-4377-98cc-cd8252e8ecc6",
                                "parentId": "109946f9-b87b-45fa-b588-6427d7a36d17",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "109946f9-b87b-45fa-b588-6427d7a36d17 > Samsung",
                                "subCategories": [
                                    {
                                        "id": "895b8cc1-30fc-459d-9bbe-eb7189d70bde",
                                        "parentId": "639d00dc-cd11-4377-98cc-cd8252e8ecc6",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "639d00dc-cd11-4377-98cc-cd8252e8ecc6 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "fc0693e0-6a10-4e90-b4cf-05056bf19c77",
                                        "parentId": "639d00dc-cd11-4377-98cc-cd8252e8ecc6",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "639d00dc-cd11-4377-98cc-cd8252e8ecc6 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "644c3ae4-2bc9-4c8f-96ca-c08f1f114c46",
                                "parentId": "109946f9-b87b-45fa-b588-6427d7a36d17",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "109946f9-b87b-45fa-b588-6427d7a36d17 > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "91a04bbc-98b9-4784-91a2-ba39f069b0c4",
                                        "parentId": "644c3ae4-2bc9-4c8f-96ca-c08f1f114c46",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "644c3ae4-2bc9-4c8f-96ca-c08f1f114c46 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "cb23da14-d824-429b-aa5c-f5d9cac9a268",
                                "parentId": "109946f9-b87b-45fa-b588-6427d7a36d17",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "109946f9-b87b-45fa-b588-6427d7a36d17 > Beko",
                                "subCategories": [
                                    {
                                        "id": "bdaa5fd3-1165-42e9-a35f-d1fb4799aab4",
                                        "parentId": "cb23da14-d824-429b-aa5c-f5d9cac9a268",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "cb23da14-d824-429b-aa5c-f5d9cac9a268 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "b2927035-44f2-4c75-9932-b2c3ffa7e24e",
                                        "parentId": "cb23da14-d824-429b-aa5c-f5d9cac9a268",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "cb23da14-d824-429b-aa5c-f5d9cac9a268 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "52a5b004-b4a6-407e-883e-d55b1a6fc39b",
                                "parentId": "109946f9-b87b-45fa-b588-6427d7a36d17",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "109946f9-b87b-45fa-b588-6427d7a36d17 > LG",
                                "subCategories": [
                                    {
                                        "id": "37cbbcfc-bad8-4e1e-b9b3-7358fc44cff5",
                                        "parentId": "52a5b004-b4a6-407e-883e-d55b1a6fc39b",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "52a5b004-b4a6-407e-883e-d55b1a6fc39b > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "2ba2a361-0159-4c8b-99cc-6d5a22377c90",
                                        "parentId": "52a5b004-b4a6-407e-883e-d55b1a6fc39b",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "52a5b004-b4a6-407e-883e-d55b1a6fc39b > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        "id": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3",
                        "parentId": "efdc2b6e-0e07-4351-a26a-3971e4ed2a65",
                        "imgUrl": null,
                        "name": "Стиральные машины",
                        "description": "Описание Стиральные машины",
                        "level": 1,
                        "fullPath": "efdc2b6e-0e07-4351-a26a-3971e4ed2a65 > Стиральные машины",
                        "subCategories": [
                            {
                                "id": "865ea246-6455-4fc9-8e02-267fd8cf246f",
                                "parentId": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3 > Beko",
                                "subCategories": [
                                    {
                                        "id": "cb7ccd46-1b9d-4dbd-bfab-cbff7d2667ec",
                                        "parentId": "865ea246-6455-4fc9-8e02-267fd8cf246f",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "865ea246-6455-4fc9-8e02-267fd8cf246f > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "766f0d84-51dd-4112-a348-0fa93791c65e",
                                        "parentId": "865ea246-6455-4fc9-8e02-267fd8cf246f",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "865ea246-6455-4fc9-8e02-267fd8cf246f > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "7417da2e-a504-424c-b24b-1690fb6502d1",
                                "parentId": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3 > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "ffe2569b-2e22-4163-9afa-0f6fefc03ca8",
                                        "parentId": "7417da2e-a504-424c-b24b-1690fb6502d1",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "7417da2e-a504-424c-b24b-1690fb6502d1 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "9bd80fd6-5d51-40c8-820c-6438d4b41a48",
                                "parentId": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3 > Samsung",
                                "subCategories": [
                                    {
                                        "id": "c1a95243-0849-493e-b3ee-803e0a77820b",
                                        "parentId": "9bd80fd6-5d51-40c8-820c-6438d4b41a48",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "9bd80fd6-5d51-40c8-820c-6438d4b41a48 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "099969dd-f31a-4c51-b719-e944d6efc54b",
                                "parentId": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3 > LG",
                                "subCategories": [
                                    {
                                        "id": "f9c5c6a9-188f-4d28-98ad-92c3c222844a",
                                        "parentId": "099969dd-f31a-4c51-b719-e944d6efc54b",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "099969dd-f31a-4c51-b719-e944d6efc54b > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "3dda801b-58d6-4aae-863b-10a000a83600",
                                "parentId": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3 > Haier",
                                "subCategories": [
                                    {
                                        "id": "99040aec-0570-4f79-8d07-f8bcad1f04fe",
                                        "parentId": "3dda801b-58d6-4aae-863b-10a000a83600",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "3dda801b-58d6-4aae-863b-10a000a83600 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "57d82bae-ae99-4e42-be93-ae54b644e776",
                                        "parentId": "3dda801b-58d6-4aae-863b-10a000a83600",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "3dda801b-58d6-4aae-863b-10a000a83600 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "e453955c-ca4a-4b64-a69f-cdca5a16df1f",
                                "parentId": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3 > Siemens",
                                "subCategories": [
                                    {
                                        "id": "786c4b0c-e2f1-4e7a-99d8-03d44172102b",
                                        "parentId": "e453955c-ca4a-4b64-a69f-cdca5a16df1f",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "e453955c-ca4a-4b64-a69f-cdca5a16df1f > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "75f48818-6efe-4470-b789-64fba1ac0a0d",
                                        "parentId": "e453955c-ca4a-4b64-a69f-cdca5a16df1f",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "e453955c-ca4a-4b64-a69f-cdca5a16df1f > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "91755bb5-dfcc-4742-ba33-5b635eae2e12",
                                "parentId": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3 > Indesit",
                                "subCategories": [
                                    {
                                        "id": "6aff79a3-c725-4694-b44f-1bf61cbd3dbe",
                                        "parentId": "91755bb5-dfcc-4742-ba33-5b635eae2e12",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "91755bb5-dfcc-4742-ba33-5b635eae2e12 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "ea41f998-59fa-4589-aa84-825d57d4121f",
                                        "parentId": "91755bb5-dfcc-4742-ba33-5b635eae2e12",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "91755bb5-dfcc-4742-ba33-5b635eae2e12 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "a9295bce-b2b1-4801-861e-f50d32c239e5",
                                "parentId": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3 > Bosch",
                                "subCategories": [
                                    {
                                        "id": "8b7fd62e-10b3-44d5-a57f-ac1b8ac65727",
                                        "parentId": "a9295bce-b2b1-4801-861e-f50d32c239e5",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "a9295bce-b2b1-4801-861e-f50d32c239e5 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "36fbd906-2147-4ee1-92b0-16705d9ea995",
                                "parentId": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3 > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "95ac164d-28f0-4563-a953-72f11da37433",
                                        "parentId": "36fbd906-2147-4ee1-92b0-16705d9ea995",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "36fbd906-2147-4ee1-92b0-16705d9ea995 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "030341b3-f3d0-4ac6-935e-45051e568fe1",
                                        "parentId": "36fbd906-2147-4ee1-92b0-16705d9ea995",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "36fbd906-2147-4ee1-92b0-16705d9ea995 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "fc992b3c-69bf-470c-9b6f-0281b5516b6c",
                                "parentId": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "46bf5aae-3de5-4b00-8465-dee9fc01ffe3 > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "2c63d3e3-4c02-4b88-b934-2c535199c0e1",
                                        "parentId": "fc992b3c-69bf-470c-9b6f-0281b5516b6c",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "fc992b3c-69bf-470c-9b6f-0281b5516b6c > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        "id": "882eca50-4b1c-44cd-ac7d-b38c01c90050",
                        "parentId": "efdc2b6e-0e07-4351-a26a-3971e4ed2a65",
                        "imgUrl": null,
                        "name": "Холодильники",
                        "description": "Описание Холодильники",
                        "level": 1,
                        "fullPath": "efdc2b6e-0e07-4351-a26a-3971e4ed2a65 > Холодильники",
                        "subCategories": [
                            {
                                "id": "9e0a2774-1d11-4f2d-bef2-71934fcd9f3c",
                                "parentId": "882eca50-4b1c-44cd-ac7d-b38c01c90050",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "882eca50-4b1c-44cd-ac7d-b38c01c90050 > Haier",
                                "subCategories": [
                                    {
                                        "id": "0637cfcd-0d61-4b05-b538-281af3ced73c",
                                        "parentId": "9e0a2774-1d11-4f2d-bef2-71934fcd9f3c",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "9e0a2774-1d11-4f2d-bef2-71934fcd9f3c > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "43409061-8284-4cde-b8d4-8c3b91ba8f4c",
                                        "parentId": "9e0a2774-1d11-4f2d-bef2-71934fcd9f3c",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "9e0a2774-1d11-4f2d-bef2-71934fcd9f3c > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "f22abd47-4d89-4508-9377-2ffbfa622149",
                                "parentId": "882eca50-4b1c-44cd-ac7d-b38c01c90050",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "882eca50-4b1c-44cd-ac7d-b38c01c90050 > Siemens",
                                "subCategories": [
                                    {
                                        "id": "7f54c1f9-56d4-4751-8ffe-eff4a67ea18e",
                                        "parentId": "f22abd47-4d89-4508-9377-2ffbfa622149",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "f22abd47-4d89-4508-9377-2ffbfa622149 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "3194ca9d-5d05-4a17-8971-8bba43c7dfc9",
                                        "parentId": "f22abd47-4d89-4508-9377-2ffbfa622149",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "f22abd47-4d89-4508-9377-2ffbfa622149 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "88707bc0-d9de-46d9-8479-b01bc0e94106",
                                "parentId": "882eca50-4b1c-44cd-ac7d-b38c01c90050",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "882eca50-4b1c-44cd-ac7d-b38c01c90050 > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "29b4b80a-cb67-4b7a-89a6-2fdfc23f90e6",
                                        "parentId": "88707bc0-d9de-46d9-8479-b01bc0e94106",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "88707bc0-d9de-46d9-8479-b01bc0e94106 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "1a099108-ed18-43bd-a304-9e77254baf1e",
                                        "parentId": "88707bc0-d9de-46d9-8479-b01bc0e94106",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "88707bc0-d9de-46d9-8479-b01bc0e94106 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "09ea6b2b-df68-4f20-8d2b-80bd30b7f756",
                                "parentId": "882eca50-4b1c-44cd-ac7d-b38c01c90050",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "882eca50-4b1c-44cd-ac7d-b38c01c90050 > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "c86a3a16-5959-436d-98ae-fdef3029678f",
                                        "parentId": "09ea6b2b-df68-4f20-8d2b-80bd30b7f756",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "09ea6b2b-df68-4f20-8d2b-80bd30b7f756 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "1582dacb-45b6-4169-aade-d43091eb30c7",
                                        "parentId": "09ea6b2b-df68-4f20-8d2b-80bd30b7f756",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "09ea6b2b-df68-4f20-8d2b-80bd30b7f756 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "6363dda8-b84d-4921-8e2c-55867e37de39",
                                "parentId": "882eca50-4b1c-44cd-ac7d-b38c01c90050",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "882eca50-4b1c-44cd-ac7d-b38c01c90050 > Samsung",
                                "subCategories": [
                                    {
                                        "id": "c3a4768a-eb88-4ba9-9927-7e9d5ce325bb",
                                        "parentId": "6363dda8-b84d-4921-8e2c-55867e37de39",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "6363dda8-b84d-4921-8e2c-55867e37de39 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "294b35e9-e99d-4b88-845b-61bc49a8473e",
                                        "parentId": "6363dda8-b84d-4921-8e2c-55867e37de39",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "6363dda8-b84d-4921-8e2c-55867e37de39 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "4f1e1fb0-f852-4486-9d0e-188e70f6f5ca",
                                "parentId": "882eca50-4b1c-44cd-ac7d-b38c01c90050",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "882eca50-4b1c-44cd-ac7d-b38c01c90050 > Indesit",
                                "subCategories": [
                                    {
                                        "id": "b57aa8ff-891d-418f-be50-5a3080603bc8",
                                        "parentId": "4f1e1fb0-f852-4486-9d0e-188e70f6f5ca",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "4f1e1fb0-f852-4486-9d0e-188e70f6f5ca > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "51c307e6-b32e-47ff-9ed4-242464439ae3",
                                "parentId": "882eca50-4b1c-44cd-ac7d-b38c01c90050",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "882eca50-4b1c-44cd-ac7d-b38c01c90050 > Bosch",
                                "subCategories": [
                                    {
                                        "id": "85642097-af7f-4ae4-b419-1f3b221ee004",
                                        "parentId": "51c307e6-b32e-47ff-9ed4-242464439ae3",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "51c307e6-b32e-47ff-9ed4-242464439ae3 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "6b853313-4f54-4e93-9ec9-949b1ed0dea5",
                                "parentId": "882eca50-4b1c-44cd-ac7d-b38c01c90050",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "882eca50-4b1c-44cd-ac7d-b38c01c90050 > LG",
                                "subCategories": [
                                    {
                                        "id": "146d3e23-b75f-4f5c-99ca-a10f7da8c21a",
                                        "parentId": "6b853313-4f54-4e93-9ec9-949b1ed0dea5",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "6b853313-4f54-4e93-9ec9-949b1ed0dea5 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "6325a274-652d-4dcf-88d7-240b6e7ff303",
                                        "parentId": "6b853313-4f54-4e93-9ec9-949b1ed0dea5",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "6b853313-4f54-4e93-9ec9-949b1ed0dea5 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "9d4003c9-1ed0-4179-98aa-48661d258eab",
                                "parentId": "882eca50-4b1c-44cd-ac7d-b38c01c90050",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "882eca50-4b1c-44cd-ac7d-b38c01c90050 > Beko",
                                "subCategories": [
                                    {
                                        "id": "c04c6e61-2b1c-453b-b120-9a217d86ca0e",
                                        "parentId": "9d4003c9-1ed0-4179-98aa-48661d258eab",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "9d4003c9-1ed0-4179-98aa-48661d258eab > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "4a1c2f0a-8ddf-41ff-a69d-3aa9fb4d65ca",
                                "parentId": "882eca50-4b1c-44cd-ac7d-b38c01c90050",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "882eca50-4b1c-44cd-ac7d-b38c01c90050 > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "5551254b-c206-44ce-8d48-0cbb013ef568",
                                        "parentId": "4a1c2f0a-8ddf-41ff-a69d-3aa9fb4d65ca",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "4a1c2f0a-8ddf-41ff-a69d-3aa9fb4d65ca > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    }
                ]
            },
            {
                "id": "2f2e239e-e0ec-4af6-afe6-44691cd3e6a0",
                "parentId": "",
                "imgUrl": null,
                "name": "Кухонная техника",
                "description": "Описание Кухонная техника",
                "level": 0,
                "fullPath": "Кухонная техника",
                "subCategories": [
                    {
                        "id": "2148e065-abfb-46fb-87f7-dadc226a9166",
                        "parentId": "2f2e239e-e0ec-4af6-afe6-44691cd3e6a0",
                        "imgUrl": null,
                        "name": "Холодильники",
                        "description": "Описание Холодильники",
                        "level": 1,
                        "fullPath": "2f2e239e-e0ec-4af6-afe6-44691cd3e6a0 > Холодильники",
                        "subCategories": [
                            {
                                "id": "26ab1507-3b4d-4986-bfda-c2b7228b03e9",
                                "parentId": "2148e065-abfb-46fb-87f7-dadc226a9166",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "2148e065-abfb-46fb-87f7-dadc226a9166 > Siemens",
                                "subCategories": [
                                    {
                                        "id": "721fb5ed-b310-441f-8939-f492b2bdfdb7",
                                        "parentId": "26ab1507-3b4d-4986-bfda-c2b7228b03e9",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "26ab1507-3b4d-4986-bfda-c2b7228b03e9 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "1d83e00b-609e-4e5a-b46a-1b62ce9a3026",
                                "parentId": "2148e065-abfb-46fb-87f7-dadc226a9166",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "2148e065-abfb-46fb-87f7-dadc226a9166 > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "cf61cee4-af59-4ff9-9953-c516ae8f22d6",
                                        "parentId": "1d83e00b-609e-4e5a-b46a-1b62ce9a3026",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "1d83e00b-609e-4e5a-b46a-1b62ce9a3026 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "56c4a08a-755d-40b5-bd55-50e2d93d96d9",
                                        "parentId": "1d83e00b-609e-4e5a-b46a-1b62ce9a3026",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "1d83e00b-609e-4e5a-b46a-1b62ce9a3026 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "30d17e6c-48fe-416f-8733-e99de20435a7",
                                "parentId": "2148e065-abfb-46fb-87f7-dadc226a9166",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "2148e065-abfb-46fb-87f7-dadc226a9166 > Samsung",
                                "subCategories": [
                                    {
                                        "id": "099ccdd9-3d58-46ad-b25c-2138416823b2",
                                        "parentId": "30d17e6c-48fe-416f-8733-e99de20435a7",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "30d17e6c-48fe-416f-8733-e99de20435a7 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "b68d1b08-9bbd-40de-a867-900af741ca67",
                                "parentId": "2148e065-abfb-46fb-87f7-dadc226a9166",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "2148e065-abfb-46fb-87f7-dadc226a9166 > Haier",
                                "subCategories": [
                                    {
                                        "id": "7cc402a2-5779-411b-9f6b-133f4201b331",
                                        "parentId": "b68d1b08-9bbd-40de-a867-900af741ca67",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "b68d1b08-9bbd-40de-a867-900af741ca67 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "baee7093-df82-476a-9ba2-bef5f587e919",
                                        "parentId": "b68d1b08-9bbd-40de-a867-900af741ca67",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "b68d1b08-9bbd-40de-a867-900af741ca67 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "d9d3a826-e88d-4660-a208-46b3912ede0b",
                                "parentId": "2148e065-abfb-46fb-87f7-dadc226a9166",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "2148e065-abfb-46fb-87f7-dadc226a9166 > Indesit",
                                "subCategories": [
                                    {
                                        "id": "45bf1e60-a30f-49d8-9c10-10c2d2aaf85f",
                                        "parentId": "d9d3a826-e88d-4660-a208-46b3912ede0b",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "d9d3a826-e88d-4660-a208-46b3912ede0b > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "fdd823d3-8042-468c-8803-c5fb0441b1b9",
                                        "parentId": "d9d3a826-e88d-4660-a208-46b3912ede0b",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "d9d3a826-e88d-4660-a208-46b3912ede0b > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "4f61eb14-de6f-4c2d-8348-f211d87d8b48",
                                "parentId": "2148e065-abfb-46fb-87f7-dadc226a9166",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "2148e065-abfb-46fb-87f7-dadc226a9166 > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "f220e75a-a068-4a69-a3b5-a3d51a4519fb",
                                        "parentId": "4f61eb14-de6f-4c2d-8348-f211d87d8b48",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "4f61eb14-de6f-4c2d-8348-f211d87d8b48 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "e3cb4d90-b543-40d6-92d4-795dc528a93b",
                                "parentId": "2148e065-abfb-46fb-87f7-dadc226a9166",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "2148e065-abfb-46fb-87f7-dadc226a9166 > Bosch",
                                "subCategories": [
                                    {
                                        "id": "160d49ec-756b-4b05-bdc6-f06f95cdcbd0",
                                        "parentId": "e3cb4d90-b543-40d6-92d4-795dc528a93b",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "e3cb4d90-b543-40d6-92d4-795dc528a93b > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "12d68a40-5b94-41cc-944d-05906f3f8e0b",
                                "parentId": "2148e065-abfb-46fb-87f7-dadc226a9166",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "2148e065-abfb-46fb-87f7-dadc226a9166 > Beko",
                                "subCategories": [
                                    {
                                        "id": "53c0ed7c-3c9d-4414-865b-3a679121826d",
                                        "parentId": "12d68a40-5b94-41cc-944d-05906f3f8e0b",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "12d68a40-5b94-41cc-944d-05906f3f8e0b > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "253ae785-144f-4bbf-9150-e9d9e08e76cd",
                                "parentId": "2148e065-abfb-46fb-87f7-dadc226a9166",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "2148e065-abfb-46fb-87f7-dadc226a9166 > LG",
                                "subCategories": [
                                    {
                                        "id": "3bab0e5a-4066-4be2-877d-b6db7772287a",
                                        "parentId": "253ae785-144f-4bbf-9150-e9d9e08e76cd",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "253ae785-144f-4bbf-9150-e9d9e08e76cd > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "c5f6e7d4-a440-46aa-a219-d444c52008a7",
                                        "parentId": "253ae785-144f-4bbf-9150-e9d9e08e76cd",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "253ae785-144f-4bbf-9150-e9d9e08e76cd > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "37574e92-9f85-4870-b9b3-b05f9715d14d",
                                "parentId": "2148e065-abfb-46fb-87f7-dadc226a9166",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "2148e065-abfb-46fb-87f7-dadc226a9166 > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "f7908cad-61c7-4399-a32e-c9545c7710d2",
                                        "parentId": "37574e92-9f85-4870-b9b3-b05f9715d14d",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "37574e92-9f85-4870-b9b3-b05f9715d14d > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "a904787b-4e36-4ce5-891b-97b32051b0cd",
                                        "parentId": "37574e92-9f85-4870-b9b3-b05f9715d14d",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "37574e92-9f85-4870-b9b3-b05f9715d14d > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        "id": "a1ee7839-145e-4797-b9ae-6d1276962d1a",
                        "parentId": "2f2e239e-e0ec-4af6-afe6-44691cd3e6a0",
                        "imgUrl": null,
                        "name": "Посудомоечные машины",
                        "description": "Описание Посудомоечные машины",
                        "level": 1,
                        "fullPath": "2f2e239e-e0ec-4af6-afe6-44691cd3e6a0 > Посудомоечные машины",
                        "subCategories": [
                            {
                                "id": "42a46e4e-6086-4b80-bb53-163f43404e86",
                                "parentId": "a1ee7839-145e-4797-b9ae-6d1276962d1a",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "a1ee7839-145e-4797-b9ae-6d1276962d1a > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "9fd59246-c97b-45e2-bd47-5cb333b1103e",
                                        "parentId": "42a46e4e-6086-4b80-bb53-163f43404e86",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "42a46e4e-6086-4b80-bb53-163f43404e86 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "cd34b990-1a9c-4cc7-9bf6-084f73d980cc",
                                "parentId": "a1ee7839-145e-4797-b9ae-6d1276962d1a",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "a1ee7839-145e-4797-b9ae-6d1276962d1a > Bosch",
                                "subCategories": [
                                    {
                                        "id": "d980254c-6fe2-48e5-9635-11aac27c8c58",
                                        "parentId": "cd34b990-1a9c-4cc7-9bf6-084f73d980cc",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "cd34b990-1a9c-4cc7-9bf6-084f73d980cc > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "80bb4aca-2010-4e17-85c8-1f1df8126258",
                                "parentId": "a1ee7839-145e-4797-b9ae-6d1276962d1a",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "a1ee7839-145e-4797-b9ae-6d1276962d1a > Haier",
                                "subCategories": [
                                    {
                                        "id": "c4d3466a-37d6-47d2-a36e-265372305601",
                                        "parentId": "80bb4aca-2010-4e17-85c8-1f1df8126258",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "80bb4aca-2010-4e17-85c8-1f1df8126258 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "bf1b80f1-b30f-438f-b3e1-d22661cd0ac8",
                                        "parentId": "80bb4aca-2010-4e17-85c8-1f1df8126258",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "80bb4aca-2010-4e17-85c8-1f1df8126258 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "f3d739dd-f101-4fcb-9a6a-cbe2dcc4820a",
                                "parentId": "a1ee7839-145e-4797-b9ae-6d1276962d1a",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "a1ee7839-145e-4797-b9ae-6d1276962d1a > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "bbb4586a-ffb2-41cf-ac67-17e1b2774b73",
                                        "parentId": "f3d739dd-f101-4fcb-9a6a-cbe2dcc4820a",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "f3d739dd-f101-4fcb-9a6a-cbe2dcc4820a > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "883c5f09-f6e9-4091-81e3-9e71e7834969",
                                "parentId": "a1ee7839-145e-4797-b9ae-6d1276962d1a",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "a1ee7839-145e-4797-b9ae-6d1276962d1a > Samsung",
                                "subCategories": [
                                    {
                                        "id": "9ae9ba34-0d9c-4748-9363-f836ffeed971",
                                        "parentId": "883c5f09-f6e9-4091-81e3-9e71e7834969",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "883c5f09-f6e9-4091-81e3-9e71e7834969 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "e0b6bb20-fa00-4197-a156-fdbf18c0e551",
                                "parentId": "a1ee7839-145e-4797-b9ae-6d1276962d1a",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "a1ee7839-145e-4797-b9ae-6d1276962d1a > Siemens",
                                "subCategories": [
                                    {
                                        "id": "691b39ca-e640-4ba0-bcbe-662d7943e41e",
                                        "parentId": "e0b6bb20-fa00-4197-a156-fdbf18c0e551",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "e0b6bb20-fa00-4197-a156-fdbf18c0e551 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "11e09e9f-2057-42ac-b42b-a083943ec683",
                                        "parentId": "e0b6bb20-fa00-4197-a156-fdbf18c0e551",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "e0b6bb20-fa00-4197-a156-fdbf18c0e551 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "41a26e78-7543-4ad2-98cb-078e3a732446",
                                "parentId": "a1ee7839-145e-4797-b9ae-6d1276962d1a",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "a1ee7839-145e-4797-b9ae-6d1276962d1a > Beko",
                                "subCategories": [
                                    {
                                        "id": "eef3a471-7da5-4b47-b9d6-56e15a773022",
                                        "parentId": "41a26e78-7543-4ad2-98cb-078e3a732446",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "41a26e78-7543-4ad2-98cb-078e3a732446 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "d443e4c4-e8e6-4c42-b138-beedbfce3fee",
                                "parentId": "a1ee7839-145e-4797-b9ae-6d1276962d1a",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "a1ee7839-145e-4797-b9ae-6d1276962d1a > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "3df732cc-b4bb-4b31-8687-13dc13dbe598",
                                        "parentId": "d443e4c4-e8e6-4c42-b138-beedbfce3fee",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "d443e4c4-e8e6-4c42-b138-beedbfce3fee > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "b6471953-3cdd-43f5-b7f3-1618263a3520",
                                "parentId": "a1ee7839-145e-4797-b9ae-6d1276962d1a",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "a1ee7839-145e-4797-b9ae-6d1276962d1a > Indesit",
                                "subCategories": [
                                    {
                                        "id": "35b2631b-f4b0-4fa0-bf2a-c69674c2123a",
                                        "parentId": "b6471953-3cdd-43f5-b7f3-1618263a3520",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "b6471953-3cdd-43f5-b7f3-1618263a3520 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "935231ee-3666-42e2-a53a-fc104afa028d",
                                "parentId": "a1ee7839-145e-4797-b9ae-6d1276962d1a",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "a1ee7839-145e-4797-b9ae-6d1276962d1a > LG",
                                "subCategories": [
                                    {
                                        "id": "18e4128a-a285-46d4-af16-e360ddb1bcb6",
                                        "parentId": "935231ee-3666-42e2-a53a-fc104afa028d",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "935231ee-3666-42e2-a53a-fc104afa028d > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        "id": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777",
                        "parentId": "2f2e239e-e0ec-4af6-afe6-44691cd3e6a0",
                        "imgUrl": null,
                        "name": "Духовые шкафы",
                        "description": "Описание Духовые шкафы",
                        "level": 1,
                        "fullPath": "2f2e239e-e0ec-4af6-afe6-44691cd3e6a0 > Духовые шкафы",
                        "subCategories": [
                            {
                                "id": "fedbdbf1-c2cc-4985-b64f-bfe81cedcab5",
                                "parentId": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777 > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "6c54f149-a370-4ea9-b40a-a85b5b385cd5",
                                        "parentId": "fedbdbf1-c2cc-4985-b64f-bfe81cedcab5",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "fedbdbf1-c2cc-4985-b64f-bfe81cedcab5 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "dbade1bd-cc8f-461a-a30f-84fcf996b9d5",
                                "parentId": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777 > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "c5cc4418-f545-42a0-8d65-4f3e6f1d218f",
                                        "parentId": "dbade1bd-cc8f-461a-a30f-84fcf996b9d5",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "dbade1bd-cc8f-461a-a30f-84fcf996b9d5 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "7cddd01f-1ad9-493c-a897-f8bb025b4c3c",
                                "parentId": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777 > Beko",
                                "subCategories": [
                                    {
                                        "id": "99141229-b0e6-4f99-bcfe-7a0cba713834",
                                        "parentId": "7cddd01f-1ad9-493c-a897-f8bb025b4c3c",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "7cddd01f-1ad9-493c-a897-f8bb025b4c3c > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "c7676d08-ae01-4e9f-b4ca-68dee790540b",
                                "parentId": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777 > Siemens",
                                "subCategories": [
                                    {
                                        "id": "10f95b45-0de8-49db-b328-2b535ba3b81b",
                                        "parentId": "c7676d08-ae01-4e9f-b4ca-68dee790540b",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "c7676d08-ae01-4e9f-b4ca-68dee790540b > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "bbc4c5f3-2b45-4d6d-86ff-d010ec20aceb",
                                        "parentId": "c7676d08-ae01-4e9f-b4ca-68dee790540b",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "c7676d08-ae01-4e9f-b4ca-68dee790540b > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "38ae8331-6af3-4ee3-84bf-83007cd3aa86",
                                "parentId": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777 > Samsung",
                                "subCategories": [
                                    {
                                        "id": "907d47a5-d571-42bf-b224-cb942913a093",
                                        "parentId": "38ae8331-6af3-4ee3-84bf-83007cd3aa86",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "38ae8331-6af3-4ee3-84bf-83007cd3aa86 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "e39db717-b7a1-4fb7-8135-9a9497f9dfe3",
                                        "parentId": "38ae8331-6af3-4ee3-84bf-83007cd3aa86",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "38ae8331-6af3-4ee3-84bf-83007cd3aa86 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "b398f5d0-bab1-4bce-8a49-a534d3a2ce0e",
                                "parentId": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777 > Indesit",
                                "subCategories": [
                                    {
                                        "id": "6f212b94-3d43-4098-a69e-9fd030ea98c3",
                                        "parentId": "b398f5d0-bab1-4bce-8a49-a534d3a2ce0e",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "b398f5d0-bab1-4bce-8a49-a534d3a2ce0e > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "665da7fc-c24b-4b41-a2ff-24a265ae3cc4",
                                        "parentId": "b398f5d0-bab1-4bce-8a49-a534d3a2ce0e",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "b398f5d0-bab1-4bce-8a49-a534d3a2ce0e > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "cb65c768-d361-4ad7-af94-67a4a21251b0",
                                "parentId": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777 > Bosch",
                                "subCategories": [
                                    {
                                        "id": "de046fa6-68c8-4e20-99cf-cb90d321233c",
                                        "parentId": "cb65c768-d361-4ad7-af94-67a4a21251b0",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "cb65c768-d361-4ad7-af94-67a4a21251b0 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "b13c7aed-f2bb-4328-bdad-f1a24a1e91dd",
                                        "parentId": "cb65c768-d361-4ad7-af94-67a4a21251b0",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "cb65c768-d361-4ad7-af94-67a4a21251b0 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "94b04de5-c32a-4462-9e35-b5ddcb3aaf64",
                                "parentId": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777 > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "a4cbfe4e-0255-4c51-a54b-2dd817251e0e",
                                        "parentId": "94b04de5-c32a-4462-9e35-b5ddcb3aaf64",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "94b04de5-c32a-4462-9e35-b5ddcb3aaf64 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "f978254d-ae90-4bc2-8e3d-e3a91e706652",
                                        "parentId": "94b04de5-c32a-4462-9e35-b5ddcb3aaf64",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "94b04de5-c32a-4462-9e35-b5ddcb3aaf64 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "afda4aff-0e49-4716-beee-e6aaee97b711",
                                "parentId": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777 > Haier",
                                "subCategories": [
                                    {
                                        "id": "63fc9c2f-3276-4b70-aa4d-6c9a5a249931",
                                        "parentId": "afda4aff-0e49-4716-beee-e6aaee97b711",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "afda4aff-0e49-4716-beee-e6aaee97b711 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "16b0b02d-53ed-43b2-b94e-d46fc5856c41",
                                "parentId": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "5f38af70-1a9d-40c7-bfc6-e8e3c11b4777 > LG",
                                "subCategories": [
                                    {
                                        "id": "40716288-26a3-48c2-9961-4d5e5668c757",
                                        "parentId": "16b0b02d-53ed-43b2-b94e-d46fc5856c41",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "16b0b02d-53ed-43b2-b94e-d46fc5856c41 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        "id": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405",
                        "parentId": "2f2e239e-e0ec-4af6-afe6-44691cd3e6a0",
                        "imgUrl": null,
                        "name": "Стиральные машины",
                        "description": "Описание Стиральные машины",
                        "level": 1,
                        "fullPath": "2f2e239e-e0ec-4af6-afe6-44691cd3e6a0 > Стиральные машины",
                        "subCategories": [
                            {
                                "id": "d64c0f0c-3ab3-4378-acd0-ca0bf13a0ae3",
                                "parentId": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405 > Samsung",
                                "subCategories": [
                                    {
                                        "id": "a70afb8f-e6d9-47b0-bc0f-12e57939c129",
                                        "parentId": "d64c0f0c-3ab3-4378-acd0-ca0bf13a0ae3",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "d64c0f0c-3ab3-4378-acd0-ca0bf13a0ae3 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "2969f81b-6e47-42fe-8d7d-684bc9aa7d3d",
                                        "parentId": "d64c0f0c-3ab3-4378-acd0-ca0bf13a0ae3",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "d64c0f0c-3ab3-4378-acd0-ca0bf13a0ae3 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "a8e148f6-b8a8-457a-b7fb-7fdd5529ac6c",
                                "parentId": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405 > Beko",
                                "subCategories": [
                                    {
                                        "id": "74abdc15-196e-4ecc-83ff-d8b5edfae7ee",
                                        "parentId": "a8e148f6-b8a8-457a-b7fb-7fdd5529ac6c",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "a8e148f6-b8a8-457a-b7fb-7fdd5529ac6c > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "bd4cf891-2aa6-4c5a-bab4-e60e0d17dbbc",
                                        "parentId": "a8e148f6-b8a8-457a-b7fb-7fdd5529ac6c",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "a8e148f6-b8a8-457a-b7fb-7fdd5529ac6c > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "2f8cca82-9965-4147-a04a-bad6241bf9be",
                                "parentId": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405 > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "64a85905-64dd-440d-aea3-24ebe6193886",
                                        "parentId": "2f8cca82-9965-4147-a04a-bad6241bf9be",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "2f8cca82-9965-4147-a04a-bad6241bf9be > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "166b9d90-8873-406f-8d97-2135554c63a4",
                                "parentId": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405 > Indesit",
                                "subCategories": [
                                    {
                                        "id": "789f9610-e2af-49db-8270-e60b8f4bc7a5",
                                        "parentId": "166b9d90-8873-406f-8d97-2135554c63a4",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "166b9d90-8873-406f-8d97-2135554c63a4 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "a474b2c9-8be3-4dcc-939e-84c18a9dae98",
                                "parentId": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405 > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "c1a45f29-2d16-45c8-acb0-8c21974ea002",
                                        "parentId": "a474b2c9-8be3-4dcc-939e-84c18a9dae98",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "a474b2c9-8be3-4dcc-939e-84c18a9dae98 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "b9d7155e-2dc5-4a6f-80af-83e3e513a2bf",
                                "parentId": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405 > Siemens",
                                "subCategories": [
                                    {
                                        "id": "1771c98f-3fbc-4509-9c30-ab38b90eedd3",
                                        "parentId": "b9d7155e-2dc5-4a6f-80af-83e3e513a2bf",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "b9d7155e-2dc5-4a6f-80af-83e3e513a2bf > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "76978414-cbd4-4b08-ba05-e3c3ea130cd3",
                                        "parentId": "b9d7155e-2dc5-4a6f-80af-83e3e513a2bf",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "b9d7155e-2dc5-4a6f-80af-83e3e513a2bf > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "0a943200-0435-462e-858c-f6ea5d383b43",
                                "parentId": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405 > Haier",
                                "subCategories": [
                                    {
                                        "id": "4f827cf9-2990-4582-982c-b02e5f0b1852",
                                        "parentId": "0a943200-0435-462e-858c-f6ea5d383b43",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "0a943200-0435-462e-858c-f6ea5d383b43 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "66d87dd5-dadb-49a7-9323-baf004258fd1",
                                        "parentId": "0a943200-0435-462e-858c-f6ea5d383b43",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "0a943200-0435-462e-858c-f6ea5d383b43 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "202fd49a-918a-4e68-bc78-46b80fa8d869",
                                "parentId": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405 > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "26f3f28e-c265-4946-8843-91e1474eef0f",
                                        "parentId": "202fd49a-918a-4e68-bc78-46b80fa8d869",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "202fd49a-918a-4e68-bc78-46b80fa8d869 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "bfde68e8-f759-4f37-a35a-8547d7de840d",
                                        "parentId": "202fd49a-918a-4e68-bc78-46b80fa8d869",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "202fd49a-918a-4e68-bc78-46b80fa8d869 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "b6042357-ce26-44f5-b6b9-6c4739f36515",
                                "parentId": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405 > LG",
                                "subCategories": [
                                    {
                                        "id": "5df8bb1f-8d5f-4707-bf7a-4a47d5379f3b",
                                        "parentId": "b6042357-ce26-44f5-b6b9-6c4739f36515",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "b6042357-ce26-44f5-b6b9-6c4739f36515 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "f9126225-970c-4c2d-98d1-7d1bcebb8562",
                                        "parentId": "b6042357-ce26-44f5-b6b9-6c4739f36515",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "b6042357-ce26-44f5-b6b9-6c4739f36515 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "be9dc6a0-54e8-4cc7-92ba-54542033310c",
                                "parentId": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "d423a0be-f5a4-4e14-b0ec-c8cc83f6b405 > Bosch",
                                "subCategories": [
                                    {
                                        "id": "72bbd20a-829a-490b-9340-a5cebd9441bc",
                                        "parentId": "be9dc6a0-54e8-4cc7-92ba-54542033310c",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "be9dc6a0-54e8-4cc7-92ba-54542033310c > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    }
                ]
            },
            {
                "id": "9b1ea1c8-45fa-424e-a4b9-b35941e7dfc0",
                "parentId": "",
                "imgUrl": null,
                "name": "Климатическая техника",
                "description": "Описание Климатическая техника",
                "level": 0,
                "fullPath": "Климатическая техника",
                "subCategories": [
                    {
                        "id": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2",
                        "parentId": "9b1ea1c8-45fa-424e-a4b9-b35941e7dfc0",
                        "imgUrl": null,
                        "name": "Посудомоечные машины",
                        "description": "Описание Посудомоечные машины",
                        "level": 1,
                        "fullPath": "9b1ea1c8-45fa-424e-a4b9-b35941e7dfc0 > Посудомоечные машины",
                        "subCategories": [
                            {
                                "id": "d6c49853-e4eb-4760-bb46-80f95490874e",
                                "parentId": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2 > Beko",
                                "subCategories": [
                                    {
                                        "id": "9cb6a1ea-d2a1-4073-b315-efbfbb1a6cd7",
                                        "parentId": "d6c49853-e4eb-4760-bb46-80f95490874e",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "d6c49853-e4eb-4760-bb46-80f95490874e > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "3cbdd172-bcfb-4229-8862-f8dedd1e226b",
                                "parentId": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2 > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "0f3d7276-9ecc-4f87-ac15-c8e2bd0761dd",
                                        "parentId": "3cbdd172-bcfb-4229-8862-f8dedd1e226b",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "3cbdd172-bcfb-4229-8862-f8dedd1e226b > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "089ad15e-b923-4a64-aa57-36425c352fd2",
                                "parentId": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2 > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "1a055a5a-21b6-4d21-8796-bf1106827e0c",
                                        "parentId": "089ad15e-b923-4a64-aa57-36425c352fd2",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "089ad15e-b923-4a64-aa57-36425c352fd2 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "f4b893e1-6b17-4d11-aa4e-792737097973",
                                        "parentId": "089ad15e-b923-4a64-aa57-36425c352fd2",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "089ad15e-b923-4a64-aa57-36425c352fd2 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "b4b441a1-43d3-4773-b134-1273d635c662",
                                "parentId": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2 > Bosch",
                                "subCategories": [
                                    {
                                        "id": "3e422df1-6b28-48cc-8018-ffea0b2a7ef5",
                                        "parentId": "b4b441a1-43d3-4773-b134-1273d635c662",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "b4b441a1-43d3-4773-b134-1273d635c662 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "4b2d3563-1ed0-47c8-be41-4e87f3620cd3",
                                        "parentId": "b4b441a1-43d3-4773-b134-1273d635c662",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "b4b441a1-43d3-4773-b134-1273d635c662 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "ece33679-3537-4791-970c-14e85ec9f821",
                                "parentId": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2 > Samsung",
                                "subCategories": [
                                    {
                                        "id": "d9f2a726-c529-4dd2-ad41-a2a510b2579b",
                                        "parentId": "ece33679-3537-4791-970c-14e85ec9f821",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "ece33679-3537-4791-970c-14e85ec9f821 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "1a1e78d4-0ed7-4979-bed5-f31c966f300c",
                                "parentId": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2 > Siemens",
                                "subCategories": [
                                    {
                                        "id": "8027664c-62d8-42c3-ac24-23460ff5cb99",
                                        "parentId": "1a1e78d4-0ed7-4979-bed5-f31c966f300c",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "1a1e78d4-0ed7-4979-bed5-f31c966f300c > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "89ba10ba-2b98-4c25-b803-64049f9f77e5",
                                        "parentId": "1a1e78d4-0ed7-4979-bed5-f31c966f300c",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "1a1e78d4-0ed7-4979-bed5-f31c966f300c > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "cead7a06-4e86-4b69-94ea-09717772c28c",
                                "parentId": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2 > LG",
                                "subCategories": [
                                    {
                                        "id": "2c4dc6d8-31c7-4c5c-ad2b-b4f1bd0dc037",
                                        "parentId": "cead7a06-4e86-4b69-94ea-09717772c28c",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "cead7a06-4e86-4b69-94ea-09717772c28c > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "a20e5b62-652f-43c5-8b6a-5a431a2b26a5",
                                        "parentId": "cead7a06-4e86-4b69-94ea-09717772c28c",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "cead7a06-4e86-4b69-94ea-09717772c28c > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "aeb0070d-d2a8-4cd7-8351-492de30df1f8",
                                "parentId": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2 > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "85821db2-717e-4ffd-add2-ba464d7df337",
                                        "parentId": "aeb0070d-d2a8-4cd7-8351-492de30df1f8",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "aeb0070d-d2a8-4cd7-8351-492de30df1f8 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "79c778ac-62c7-4a8e-a040-cd5fa39a4cd9",
                                "parentId": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2 > Haier",
                                "subCategories": [
                                    {
                                        "id": "f42070b9-241a-4b36-a6ce-a4b2d98ed638",
                                        "parentId": "79c778ac-62c7-4a8e-a040-cd5fa39a4cd9",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "79c778ac-62c7-4a8e-a040-cd5fa39a4cd9 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "0000cca5-796e-48df-bc9b-d9067bcdc4ac",
                                        "parentId": "79c778ac-62c7-4a8e-a040-cd5fa39a4cd9",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "79c778ac-62c7-4a8e-a040-cd5fa39a4cd9 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "2fe83a0a-6921-49d6-a55a-c3fdd316b573",
                                "parentId": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "8d6bc1fc-8591-4c85-b2af-b2fa2b80c5b2 > Indesit",
                                "subCategories": [
                                    {
                                        "id": "ba5063d7-15b9-4c35-9022-53d41b07a0a5",
                                        "parentId": "2fe83a0a-6921-49d6-a55a-c3fdd316b573",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "2fe83a0a-6921-49d6-a55a-c3fdd316b573 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "36276217-d4f8-4a8d-ab9b-fab62485d39f",
                                        "parentId": "2fe83a0a-6921-49d6-a55a-c3fdd316b573",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "2fe83a0a-6921-49d6-a55a-c3fdd316b573 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        "id": "d08eeeae-64e2-47a1-be64-509f6dc2cb92",
                        "parentId": "9b1ea1c8-45fa-424e-a4b9-b35941e7dfc0",
                        "imgUrl": null,
                        "name": "Духовые шкафы",
                        "description": "Описание Духовые шкафы",
                        "level": 1,
                        "fullPath": "9b1ea1c8-45fa-424e-a4b9-b35941e7dfc0 > Духовые шкафы",
                        "subCategories": [
                            {
                                "id": "21b7a3ad-dcd6-4776-bef3-e764dd3446b8",
                                "parentId": "d08eeeae-64e2-47a1-be64-509f6dc2cb92",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "d08eeeae-64e2-47a1-be64-509f6dc2cb92 > Haier",
                                "subCategories": [
                                    {
                                        "id": "e57ff802-4724-4923-a221-0b18c7dd4662",
                                        "parentId": "21b7a3ad-dcd6-4776-bef3-e764dd3446b8",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "21b7a3ad-dcd6-4776-bef3-e764dd3446b8 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "e9fc3566-63a3-4db7-88be-3683f5b49d40",
                                        "parentId": "21b7a3ad-dcd6-4776-bef3-e764dd3446b8",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "21b7a3ad-dcd6-4776-bef3-e764dd3446b8 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "f4cddf81-3344-4386-ab31-9b044f1bf729",
                                "parentId": "d08eeeae-64e2-47a1-be64-509f6dc2cb92",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "d08eeeae-64e2-47a1-be64-509f6dc2cb92 > Indesit",
                                "subCategories": [
                                    {
                                        "id": "f696ae4e-f373-49c1-8cab-d338c639dbbe",
                                        "parentId": "f4cddf81-3344-4386-ab31-9b044f1bf729",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "f4cddf81-3344-4386-ab31-9b044f1bf729 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "dd0ef07f-7d89-4057-a768-2df7c5fd2fcf",
                                        "parentId": "f4cddf81-3344-4386-ab31-9b044f1bf729",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "f4cddf81-3344-4386-ab31-9b044f1bf729 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "c03675e4-5cff-4220-a381-0ed7f892f068",
                                "parentId": "d08eeeae-64e2-47a1-be64-509f6dc2cb92",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "d08eeeae-64e2-47a1-be64-509f6dc2cb92 > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "f3281b34-7345-4ab9-ba11-819a9c339306",
                                        "parentId": "c03675e4-5cff-4220-a381-0ed7f892f068",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "c03675e4-5cff-4220-a381-0ed7f892f068 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "6dd00091-2bc8-4a54-bf85-2171d24f5e32",
                                "parentId": "d08eeeae-64e2-47a1-be64-509f6dc2cb92",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "d08eeeae-64e2-47a1-be64-509f6dc2cb92 > Siemens",
                                "subCategories": [
                                    {
                                        "id": "858abd87-e52f-4989-a24d-93e3d396cac7",
                                        "parentId": "6dd00091-2bc8-4a54-bf85-2171d24f5e32",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "6dd00091-2bc8-4a54-bf85-2171d24f5e32 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "f7a87798-9e4e-4a43-93ff-f54e50830901",
                                "parentId": "d08eeeae-64e2-47a1-be64-509f6dc2cb92",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "d08eeeae-64e2-47a1-be64-509f6dc2cb92 > LG",
                                "subCategories": [
                                    {
                                        "id": "ae3420e6-19f9-4cbd-830b-c2ef29e5a3c4",
                                        "parentId": "f7a87798-9e4e-4a43-93ff-f54e50830901",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "f7a87798-9e4e-4a43-93ff-f54e50830901 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "957d4ace-063c-41a1-ada3-ff35614081a6",
                                        "parentId": "f7a87798-9e4e-4a43-93ff-f54e50830901",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "f7a87798-9e4e-4a43-93ff-f54e50830901 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "0dca98a6-f25a-446f-bd88-b0300e5e6865",
                                "parentId": "d08eeeae-64e2-47a1-be64-509f6dc2cb92",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "d08eeeae-64e2-47a1-be64-509f6dc2cb92 > Bosch",
                                "subCategories": [
                                    {
                                        "id": "a1528a01-73c4-45c8-b6fb-21761adf620b",
                                        "parentId": "0dca98a6-f25a-446f-bd88-b0300e5e6865",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "0dca98a6-f25a-446f-bd88-b0300e5e6865 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "57a7b695-3e38-47dd-9ce2-9977936555c0",
                                "parentId": "d08eeeae-64e2-47a1-be64-509f6dc2cb92",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "d08eeeae-64e2-47a1-be64-509f6dc2cb92 > Samsung",
                                "subCategories": [
                                    {
                                        "id": "5e6b12e5-d1ff-4e25-aeb6-3355cad4bdbf",
                                        "parentId": "57a7b695-3e38-47dd-9ce2-9977936555c0",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "57a7b695-3e38-47dd-9ce2-9977936555c0 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "892fa545-53f2-4c6b-9829-26ad1d9fb3cd",
                                "parentId": "d08eeeae-64e2-47a1-be64-509f6dc2cb92",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "d08eeeae-64e2-47a1-be64-509f6dc2cb92 > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "2e72d93e-dcfa-4d8a-8fda-d34dac968578",
                                        "parentId": "892fa545-53f2-4c6b-9829-26ad1d9fb3cd",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "892fa545-53f2-4c6b-9829-26ad1d9fb3cd > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "a5b199d6-638f-4ab5-92ac-994f043b27ff",
                                        "parentId": "892fa545-53f2-4c6b-9829-26ad1d9fb3cd",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "892fa545-53f2-4c6b-9829-26ad1d9fb3cd > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "0d69ed14-2b27-43c8-92bb-2297f6dbbc70",
                                "parentId": "d08eeeae-64e2-47a1-be64-509f6dc2cb92",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "d08eeeae-64e2-47a1-be64-509f6dc2cb92 > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "44757cb7-090a-4315-9364-e8d5a501797c",
                                        "parentId": "0d69ed14-2b27-43c8-92bb-2297f6dbbc70",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "0d69ed14-2b27-43c8-92bb-2297f6dbbc70 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "c6a9c177-8794-493b-89da-40b79212e756",
                                        "parentId": "0d69ed14-2b27-43c8-92bb-2297f6dbbc70",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "0d69ed14-2b27-43c8-92bb-2297f6dbbc70 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "799e11e9-db27-4eb4-9ad3-9dedeca5a646",
                                "parentId": "d08eeeae-64e2-47a1-be64-509f6dc2cb92",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "d08eeeae-64e2-47a1-be64-509f6dc2cb92 > Beko",
                                "subCategories": [
                                    {
                                        "id": "b66f06d9-c10c-45e4-90a0-74fedbe6147a",
                                        "parentId": "799e11e9-db27-4eb4-9ad3-9dedeca5a646",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "799e11e9-db27-4eb4-9ad3-9dedeca5a646 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        "id": "38e82bbc-a141-42ea-a981-f8b62684ef2b",
                        "parentId": "9b1ea1c8-45fa-424e-a4b9-b35941e7dfc0",
                        "imgUrl": null,
                        "name": "Холодильники",
                        "description": "Описание Холодильники",
                        "level": 1,
                        "fullPath": "9b1ea1c8-45fa-424e-a4b9-b35941e7dfc0 > Холодильники",
                        "subCategories": [
                            {
                                "id": "dbf60485-4a68-4235-9d23-814f425617a9",
                                "parentId": "38e82bbc-a141-42ea-a981-f8b62684ef2b",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "38e82bbc-a141-42ea-a981-f8b62684ef2b > Siemens",
                                "subCategories": [
                                    {
                                        "id": "a9376b55-a247-44a9-b821-28f7e4e06063",
                                        "parentId": "dbf60485-4a68-4235-9d23-814f425617a9",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "dbf60485-4a68-4235-9d23-814f425617a9 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "fc1c9e48-12b5-4318-ada8-825f34cf4a4f",
                                        "parentId": "dbf60485-4a68-4235-9d23-814f425617a9",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "dbf60485-4a68-4235-9d23-814f425617a9 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "cac31489-6167-45f4-944c-ce85234e69b9",
                                "parentId": "38e82bbc-a141-42ea-a981-f8b62684ef2b",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "38e82bbc-a141-42ea-a981-f8b62684ef2b > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "3a7c20b3-4c5f-4b01-be3c-648ad70619d9",
                                        "parentId": "cac31489-6167-45f4-944c-ce85234e69b9",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "cac31489-6167-45f4-944c-ce85234e69b9 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "169c323c-5942-4a91-9f5f-e3eba4eaf148",
                                        "parentId": "cac31489-6167-45f4-944c-ce85234e69b9",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "cac31489-6167-45f4-944c-ce85234e69b9 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "d92a0e5e-a288-427f-a4e0-d4401ff80145",
                                "parentId": "38e82bbc-a141-42ea-a981-f8b62684ef2b",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "38e82bbc-a141-42ea-a981-f8b62684ef2b > Beko",
                                "subCategories": [
                                    {
                                        "id": "0c05ea59-7075-40b6-ac99-4155e1aa4dda",
                                        "parentId": "d92a0e5e-a288-427f-a4e0-d4401ff80145",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "d92a0e5e-a288-427f-a4e0-d4401ff80145 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "fa731969-e06b-4b45-a042-34e09fc82671",
                                "parentId": "38e82bbc-a141-42ea-a981-f8b62684ef2b",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "38e82bbc-a141-42ea-a981-f8b62684ef2b > LG",
                                "subCategories": [
                                    {
                                        "id": "6386fa9e-c5d7-433d-8e1c-4c84738d8bfa",
                                        "parentId": "fa731969-e06b-4b45-a042-34e09fc82671",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "fa731969-e06b-4b45-a042-34e09fc82671 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "89092678-00c7-40c9-9c1c-3bcd6008c567",
                                "parentId": "38e82bbc-a141-42ea-a981-f8b62684ef2b",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "38e82bbc-a141-42ea-a981-f8b62684ef2b > Bosch",
                                "subCategories": [
                                    {
                                        "id": "4987f147-71cb-4c10-988c-93c39a61065b",
                                        "parentId": "89092678-00c7-40c9-9c1c-3bcd6008c567",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "89092678-00c7-40c9-9c1c-3bcd6008c567 > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "a70c74d1-3c13-4990-9f54-1b96feb88aba",
                                        "parentId": "89092678-00c7-40c9-9c1c-3bcd6008c567",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "89092678-00c7-40c9-9c1c-3bcd6008c567 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "eb4b318e-89c5-4a7f-8026-31c80c94ea78",
                                "parentId": "38e82bbc-a141-42ea-a981-f8b62684ef2b",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "38e82bbc-a141-42ea-a981-f8b62684ef2b > Samsung",
                                "subCategories": [
                                    {
                                        "id": "29c3d2ba-8a4c-4b1c-8023-50bb722b76f9",
                                        "parentId": "eb4b318e-89c5-4a7f-8026-31c80c94ea78",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "eb4b318e-89c5-4a7f-8026-31c80c94ea78 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "25aa72ec-161c-4f64-a111-89cf1d0e4c18",
                                "parentId": "38e82bbc-a141-42ea-a981-f8b62684ef2b",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "38e82bbc-a141-42ea-a981-f8b62684ef2b > Haier",
                                "subCategories": [
                                    {
                                        "id": "982f08d3-73f1-4091-a3c6-9c78e1da3dca",
                                        "parentId": "25aa72ec-161c-4f64-a111-89cf1d0e4c18",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "25aa72ec-161c-4f64-a111-89cf1d0e4c18 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "1633c915-a80d-41a0-b3a8-80bf49b48940",
                                "parentId": "38e82bbc-a141-42ea-a981-f8b62684ef2b",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "38e82bbc-a141-42ea-a981-f8b62684ef2b > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "6ba2805b-6589-409f-a6dd-682be9e81c48",
                                        "parentId": "1633c915-a80d-41a0-b3a8-80bf49b48940",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "1633c915-a80d-41a0-b3a8-80bf49b48940 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "7eb5ecfe-117a-4af6-8cb3-d68d31e093fc",
                                "parentId": "38e82bbc-a141-42ea-a981-f8b62684ef2b",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "38e82bbc-a141-42ea-a981-f8b62684ef2b > Indesit",
                                "subCategories": [
                                    {
                                        "id": "b7844a1d-4074-4470-811e-3c52430734bd",
                                        "parentId": "7eb5ecfe-117a-4af6-8cb3-d68d31e093fc",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "7eb5ecfe-117a-4af6-8cb3-d68d31e093fc > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "86978d56-4728-4db4-bd50-abe25090b2ab",
                                        "parentId": "7eb5ecfe-117a-4af6-8cb3-d68d31e093fc",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "7eb5ecfe-117a-4af6-8cb3-d68d31e093fc > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "21e4c78a-f7f6-464e-aef0-3b342bd1ea0d",
                                "parentId": "38e82bbc-a141-42ea-a981-f8b62684ef2b",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "38e82bbc-a141-42ea-a981-f8b62684ef2b > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "cac01f76-f0ad-4aa6-a545-6fc6789053f8",
                                        "parentId": "21e4c78a-f7f6-464e-aef0-3b342bd1ea0d",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "21e4c78a-f7f6-464e-aef0-3b342bd1ea0d > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "ceb3d87b-cfe3-41f5-98af-64b5fa3b5a0b",
                                        "parentId": "21e4c78a-f7f6-464e-aef0-3b342bd1ea0d",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "21e4c78a-f7f6-464e-aef0-3b342bd1ea0d > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        "id": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab",
                        "parentId": "9b1ea1c8-45fa-424e-a4b9-b35941e7dfc0",
                        "imgUrl": null,
                        "name": "Стиральные машины",
                        "description": "Описание Стиральные машины",
                        "level": 1,
                        "fullPath": "9b1ea1c8-45fa-424e-a4b9-b35941e7dfc0 > Стиральные машины",
                        "subCategories": [
                            {
                                "id": "86579031-eeeb-4540-8d0d-05adfb9ce940",
                                "parentId": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab",
                                "imgUrl": null,
                                "name": "Haier",
                                "description": "Описание Haier",
                                "level": 2,
                                "fullPath": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab > Haier",
                                "subCategories": [
                                    {
                                        "id": "a9507caa-be15-44cf-8790-7ba21b26c686",
                                        "parentId": "86579031-eeeb-4540-8d0d-05adfb9ce940",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "86579031-eeeb-4540-8d0d-05adfb9ce940 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "a879cbdd-0777-494a-af35-4d1fb0dddced",
                                        "parentId": "86579031-eeeb-4540-8d0d-05adfb9ce940",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "86579031-eeeb-4540-8d0d-05adfb9ce940 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "ba6930e8-5235-4171-8515-6b7f4fc7b1c9",
                                "parentId": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab",
                                "imgUrl": null,
                                "name": "Samsung",
                                "description": "Описание Samsung",
                                "level": 2,
                                "fullPath": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab > Samsung",
                                "subCategories": [
                                    {
                                        "id": "7cb227ab-9b4d-4138-ac25-36ec5bee341e",
                                        "parentId": "ba6930e8-5235-4171-8515-6b7f4fc7b1c9",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "ba6930e8-5235-4171-8515-6b7f4fc7b1c9 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "f65da232-7a26-465f-a424-cdff8041ff7c",
                                "parentId": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab",
                                "imgUrl": null,
                                "name": "Siemens",
                                "description": "Описание Siemens",
                                "level": 2,
                                "fullPath": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab > Siemens",
                                "subCategories": [
                                    {
                                        "id": "66aa37c8-fdf1-488d-8364-a4368e997d36",
                                        "parentId": "f65da232-7a26-465f-a424-cdff8041ff7c",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "f65da232-7a26-465f-a424-cdff8041ff7c > Запасные части",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "7419d053-63fb-43b5-b969-e81a45fa2b3e",
                                        "parentId": "f65da232-7a26-465f-a424-cdff8041ff7c",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "f65da232-7a26-465f-a424-cdff8041ff7c > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "78f2283a-5cdc-462e-ac52-61e654532c22",
                                "parentId": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab",
                                "imgUrl": null,
                                "name": "Beko",
                                "description": "Описание Beko",
                                "level": 2,
                                "fullPath": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab > Beko",
                                "subCategories": [
                                    {
                                        "id": "f20aa07c-a9b7-4247-bbfa-256d64f60e33",
                                        "parentId": "78f2283a-5cdc-462e-ac52-61e654532c22",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "78f2283a-5cdc-462e-ac52-61e654532c22 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "7fd252a2-8692-478c-b639-51806ffb2f54",
                                "parentId": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab",
                                "imgUrl": null,
                                "name": "Whirlpool",
                                "description": "Описание Whirlpool",
                                "level": 2,
                                "fullPath": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab > Whirlpool",
                                "subCategories": [
                                    {
                                        "id": "791f9d97-b364-459c-bf3a-bfeeaf2ffb67",
                                        "parentId": "7fd252a2-8692-478c-b639-51806ffb2f54",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "7fd252a2-8692-478c-b639-51806ffb2f54 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "53e33438-1b73-4a5d-8ddf-08b2875be1e4",
                                "parentId": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab",
                                "imgUrl": null,
                                "name": "Indesit",
                                "description": "Описание Indesit",
                                "level": 2,
                                "fullPath": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab > Indesit",
                                "subCategories": [
                                    {
                                        "id": "a684f231-607d-4a5f-aae0-5b4dc2e7d5a3",
                                        "parentId": "53e33438-1b73-4a5d-8ddf-08b2875be1e4",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "53e33438-1b73-4a5d-8ddf-08b2875be1e4 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "ff59a451-c183-4bd7-a4d6-11a8ac329148",
                                "parentId": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab",
                                "imgUrl": null,
                                "name": "Bosch",
                                "description": "Описание Bosch",
                                "level": 2,
                                "fullPath": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab > Bosch",
                                "subCategories": [
                                    {
                                        "id": "e0bb792b-3c7d-4d68-b3e3-7a9b720926eb",
                                        "parentId": "ff59a451-c183-4bd7-a4d6-11a8ac329148",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "ff59a451-c183-4bd7-a4d6-11a8ac329148 > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "164118ad-ed5e-4730-bd1a-1b0d86fa305b",
                                "parentId": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab",
                                "imgUrl": null,
                                "name": "Gorenje",
                                "description": "Описание Gorenje",
                                "level": 2,
                                "fullPath": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab > Gorenje",
                                "subCategories": [
                                    {
                                        "id": "8a9d0dbb-c3e5-4b1b-b2f0-363f397198d5",
                                        "parentId": "164118ad-ed5e-4730-bd1a-1b0d86fa305b",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "164118ad-ed5e-4730-bd1a-1b0d86fa305b > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "a0cb0411-7527-4b0f-a094-1503bb01589d",
                                        "parentId": "164118ad-ed5e-4730-bd1a-1b0d86fa305b",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "164118ad-ed5e-4730-bd1a-1b0d86fa305b > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "d485f30c-d020-4d2a-855c-94d1fdb1be15",
                                "parentId": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab",
                                "imgUrl": null,
                                "name": "LG",
                                "description": "Описание LG",
                                "level": 2,
                                "fullPath": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab > LG",
                                "subCategories": [
                                    {
                                        "id": "a41fac68-47be-420b-acc8-79cab2abfd33",
                                        "parentId": "d485f30c-d020-4d2a-855c-94d1fdb1be15",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "d485f30c-d020-4d2a-855c-94d1fdb1be15 > Аксессуары",
                                        "subCategories": []
                                    },
                                    {
                                        "id": "412cf7a7-53d8-4952-8279-7057c418907b",
                                        "parentId": "d485f30c-d020-4d2a-855c-94d1fdb1be15",
                                        "imgUrl": null,
                                        "name": "Запасные части",
                                        "description": "Описание Запасные части",
                                        "level": 3,
                                        "fullPath": "d485f30c-d020-4d2a-855c-94d1fdb1be15 > Запасные части",
                                        "subCategories": []
                                    }
                                ]
                            },
                            {
                                "id": "d41bbc87-6102-42f9-a53c-7a4dd7a07bbc",
                                "parentId": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab",
                                "imgUrl": null,
                                "name": "Electrolux",
                                "description": "Описание Electrolux",
                                "level": 2,
                                "fullPath": "f6aea12c-0a23-4666-8a0f-3b0bf20b5fab > Electrolux",
                                "subCategories": [
                                    {
                                        "id": "790fe75d-6053-41e6-b165-419126882bae",
                                        "parentId": "d41bbc87-6102-42f9-a53c-7a4dd7a07bbc",
                                        "imgUrl": null,
                                        "name": "Аксессуары",
                                        "description": "Описание Аксессуары",
                                        "level": 3,
                                        "fullPath": "d41bbc87-6102-42f9-a53c-7a4dd7a07bbc > Аксессуары",
                                        "subCategories": []
                                    }
                                ]
                            }
                        ]
                    }
                ]
            }
        ]
    },
    {
        "id": "2",
        "parentId": "",
        "imgUrl": null,
        "name": "Автотовары",
        "description": "Описание Автотовары",
        "level": 0,
        "fullPath": "Автотовары",
        "subCategories": [
            {
                "id": "2-1",
                "parentId": "2",
                "imgUrl": null,
                "name": "Смартфоны",
                "description": "Описание Смартфоны",
                "level": 1,
                "fullPath": "2 > Смартфоны",
                "subCategories": [
                    {
                        "id": "2-1-1",
                        "parentId": "2-1",
                        "imgUrl": null,
                        "name": "Nikon",
                        "description": "Описание Nikon",
                        "level": 2,
                        "fullPath": "2-1 > Nikon",
                        "subCategories": [
                            {
                                "id": "2-1-1-1",
                                "parentId": "2-1-1",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-1-1 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-1-2",
                        "parentId": "2-1",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "2-1 > Asus",
                        "subCategories": [
                            {
                                "id": "2-1-2-1",
                                "parentId": "2-1-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-1-2 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "2-1-2-2",
                                "parentId": "2-1-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-1-2 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-1-3",
                        "parentId": "2-1",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "2-1 > Asus",
                        "subCategories": [
                            {
                                "id": "2-1-3-1",
                                "parentId": "2-1-3",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-1-3 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-1-4",
                        "parentId": "2-1",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "2-1 > HP",
                        "subCategories": [
                            {
                                "id": "2-1-4-1",
                                "parentId": "2-1-4",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-1-4 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "2-1-4-2",
                                "parentId": "2-1-4",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-1-4 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-1-5",
                        "parentId": "2-1",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "2-1 > Sony",
                        "subCategories": [
                            {
                                "id": "2-1-5-1",
                                "parentId": "2-1-5",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-1-5 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "2-1-5-2",
                                "parentId": "2-1-5",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-1-5 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-1-6",
                        "parentId": "2-1",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "2-1 > Dell",
                        "subCategories": [
                            {
                                "id": "2-1-6-1",
                                "parentId": "2-1-6",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-1-6 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "2-1-6-2",
                                "parentId": "2-1-6",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-1-6 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-1-7",
                        "parentId": "2-1",
                        "imgUrl": null,
                        "name": "Apple",
                        "description": "Описание Apple",
                        "level": 2,
                        "fullPath": "2-1 > Apple",
                        "subCategories": [
                            {
                                "id": "2-1-7-1",
                                "parentId": "2-1-7",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-1-7 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-1-8",
                        "parentId": "2-1",
                        "imgUrl": null,
                        "name": "Nikon",
                        "description": "Описание Nikon",
                        "level": 2,
                        "fullPath": "2-1 > Nikon",
                        "subCategories": [
                            {
                                "id": "2-1-8-1",
                                "parentId": "2-1-8",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-1-8 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "2-1-8-2",
                                "parentId": "2-1-8",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-1-8 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-1-9",
                        "parentId": "2-1",
                        "imgUrl": null,
                        "name": "Nikon",
                        "description": "Описание Nikon",
                        "level": 2,
                        "fullPath": "2-1 > Nikon",
                        "subCategories": [
                            {
                                "id": "2-1-9-1",
                                "parentId": "2-1-9",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-1-9 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "2-1-9-2",
                                "parentId": "2-1-9",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-1-9 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-1-10",
                        "parentId": "2-1",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "2-1 > Asus",
                        "subCategories": [
                            {
                                "id": "2-1-10-1",
                                "parentId": "2-1-10",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-1-10 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "2-1-10-2",
                                "parentId": "2-1-10",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-1-10 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            },
            {
                "id": "2-2",
                "parentId": "2",
                "imgUrl": null,
                "name": "Смартфоны",
                "description": "Описание Смартфоны",
                "level": 1,
                "fullPath": "2 > Смартфоны",
                "subCategories": [
                    {
                        "id": "2-2-1",
                        "parentId": "2-2",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "2-2 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "2-2-1-1",
                                "parentId": "2-2-1",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-2-1 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-2-2",
                        "parentId": "2-2",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "2-2 > HP",
                        "subCategories": [
                            {
                                "id": "2-2-2-1",
                                "parentId": "2-2-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-2-2 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "2-2-2-2",
                                "parentId": "2-2-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-2-2 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-2-3",
                        "parentId": "2-2",
                        "imgUrl": null,
                        "name": "Canon",
                        "description": "Описание Canon",
                        "level": 2,
                        "fullPath": "2-2 > Canon",
                        "subCategories": [
                            {
                                "id": "2-2-3-1",
                                "parentId": "2-2-3",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-2-3 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "2-2-3-2",
                                "parentId": "2-2-3",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-2-3 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-2-4",
                        "parentId": "2-2",
                        "imgUrl": null,
                        "name": "Canon",
                        "description": "Описание Canon",
                        "level": 2,
                        "fullPath": "2-2 > Canon",
                        "subCategories": [
                            {
                                "id": "2-2-4-1",
                                "parentId": "2-2-4",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-2-4 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "2-2-4-2",
                                "parentId": "2-2-4",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-2-4 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-2-5",
                        "parentId": "2-2",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "2-2 > Sony",
                        "subCategories": [
                            {
                                "id": "2-2-5-1",
                                "parentId": "2-2-5",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-2-5 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-2-6",
                        "parentId": "2-2",
                        "imgUrl": null,
                        "name": "Samsung",
                        "description": "Описание Samsung",
                        "level": 2,
                        "fullPath": "2-2 > Samsung",
                        "subCategories": [
                            {
                                "id": "2-2-6-1",
                                "parentId": "2-2-6",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-2-6 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-2-7",
                        "parentId": "2-2",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "2-2 > Asus",
                        "subCategories": [
                            {
                                "id": "2-2-7-1",
                                "parentId": "2-2-7",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-2-7 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-2-8",
                        "parentId": "2-2",
                        "imgUrl": null,
                        "name": "Samsung",
                        "description": "Описание Samsung",
                        "level": 2,
                        "fullPath": "2-2 > Samsung",
                        "subCategories": [
                            {
                                "id": "2-2-8-1",
                                "parentId": "2-2-8",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-2-8 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-2-9",
                        "parentId": "2-2",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "2-2 > Asus",
                        "subCategories": [
                            {
                                "id": "2-2-9-1",
                                "parentId": "2-2-9",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-2-9 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-2-10",
                        "parentId": "2-2",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "2-2 > HP",
                        "subCategories": [
                            {
                                "id": "2-2-10-1",
                                "parentId": "2-2-10",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-2-10 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            },
            {
                "id": "2-3",
                "parentId": "2",
                "imgUrl": null,
                "name": "Ноутбуки",
                "description": "Описание Ноутбуки",
                "level": 1,
                "fullPath": "2 > Ноутбуки",
                "subCategories": [
                    {
                        "id": "2-3-1",
                        "parentId": "2-3",
                        "imgUrl": null,
                        "name": "Canon",
                        "description": "Описание Canon",
                        "level": 2,
                        "fullPath": "2-3 > Canon",
                        "subCategories": [
                            {
                                "id": "2-3-1-1",
                                "parentId": "2-3-1",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-3-1 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "2-3-1-2",
                                "parentId": "2-3-1",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-3-1 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-3-2",
                        "parentId": "2-3",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "2-3 > LG",
                        "subCategories": [
                            {
                                "id": "2-3-2-1",
                                "parentId": "2-3-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-3-2 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "2-3-2-2",
                                "parentId": "2-3-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-3-2 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-3-3",
                        "parentId": "2-3",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "2-3 > Sony",
                        "subCategories": [
                            {
                                "id": "2-3-3-1",
                                "parentId": "2-3-3",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-3-3 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "2-3-3-2",
                                "parentId": "2-3-3",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-3-3 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-3-4",
                        "parentId": "2-3",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "2-3 > Dell",
                        "subCategories": [
                            {
                                "id": "2-3-4-1",
                                "parentId": "2-3-4",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-3-4 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "2-3-4-2",
                                "parentId": "2-3-4",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-3-4 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-3-5",
                        "parentId": "2-3",
                        "imgUrl": null,
                        "name": "Canon",
                        "description": "Описание Canon",
                        "level": 2,
                        "fullPath": "2-3 > Canon",
                        "subCategories": [
                            {
                                "id": "2-3-5-1",
                                "parentId": "2-3-5",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-3-5 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-3-6",
                        "parentId": "2-3",
                        "imgUrl": null,
                        "name": "Samsung",
                        "description": "Описание Samsung",
                        "level": 2,
                        "fullPath": "2-3 > Samsung",
                        "subCategories": [
                            {
                                "id": "2-3-6-1",
                                "parentId": "2-3-6",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-3-6 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-3-7",
                        "parentId": "2-3",
                        "imgUrl": null,
                        "name": "Samsung",
                        "description": "Описание Samsung",
                        "level": 2,
                        "fullPath": "2-3 > Samsung",
                        "subCategories": [
                            {
                                "id": "2-3-7-1",
                                "parentId": "2-3-7",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-3-7 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-3-8",
                        "parentId": "2-3",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "2-3 > Asus",
                        "subCategories": [
                            {
                                "id": "2-3-8-1",
                                "parentId": "2-3-8",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-3-8 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "2-3-8-2",
                                "parentId": "2-3-8",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-3-8 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-3-9",
                        "parentId": "2-3",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "2-3 > LG",
                        "subCategories": [
                            {
                                "id": "2-3-9-1",
                                "parentId": "2-3-9",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-3-9 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "2-3-9-2",
                                "parentId": "2-3-9",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-3-9 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-3-10",
                        "parentId": "2-3",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "2-3 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "2-3-10-1",
                                "parentId": "2-3-10",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-3-10 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "2-3-10-2",
                                "parentId": "2-3-10",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-3-10 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            },
            {
                "id": "2-4",
                "parentId": "2",
                "imgUrl": null,
                "name": "Смартфоны",
                "description": "Описание Смартфоны",
                "level": 1,
                "fullPath": "2 > Смартфоны",
                "subCategories": [
                    {
                        "id": "2-4-1",
                        "parentId": "2-4",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "2-4 > Sony",
                        "subCategories": [
                            {
                                "id": "2-4-1-1",
                                "parentId": "2-4-1",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-4-1 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-4-2",
                        "parentId": "2-4",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "2-4 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "2-4-2-1",
                                "parentId": "2-4-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-4-2 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "2-4-2-2",
                                "parentId": "2-4-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-4-2 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-4-3",
                        "parentId": "2-4",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "2-4 > Sony",
                        "subCategories": [
                            {
                                "id": "2-4-3-1",
                                "parentId": "2-4-3",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-4-3 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-4-4",
                        "parentId": "2-4",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "2-4 > Asus",
                        "subCategories": [
                            {
                                "id": "2-4-4-1",
                                "parentId": "2-4-4",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-4-4 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-4-5",
                        "parentId": "2-4",
                        "imgUrl": null,
                        "name": "Canon",
                        "description": "Описание Canon",
                        "level": 2,
                        "fullPath": "2-4 > Canon",
                        "subCategories": [
                            {
                                "id": "2-4-5-1",
                                "parentId": "2-4-5",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-4-5 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-4-6",
                        "parentId": "2-4",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "2-4 > Dell",
                        "subCategories": [
                            {
                                "id": "2-4-6-1",
                                "parentId": "2-4-6",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-4-6 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-4-7",
                        "parentId": "2-4",
                        "imgUrl": null,
                        "name": "Canon",
                        "description": "Описание Canon",
                        "level": 2,
                        "fullPath": "2-4 > Canon",
                        "subCategories": [
                            {
                                "id": "2-4-7-1",
                                "parentId": "2-4-7",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-4-7 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-4-8",
                        "parentId": "2-4",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "2-4 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "2-4-8-1",
                                "parentId": "2-4-8",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "2-4-8 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-4-9",
                        "parentId": "2-4",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "2-4 > LG",
                        "subCategories": [
                            {
                                "id": "2-4-9-1",
                                "parentId": "2-4-9",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-4-9 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "2-4-9-2",
                                "parentId": "2-4-9",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-4-9 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "2-4-10",
                        "parentId": "2-4",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "2-4 > Sony",
                        "subCategories": [
                            {
                                "id": "2-4-10-1",
                                "parentId": "2-4-10",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "2-4-10 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            }
        ]
    },
    {
        "id": "3",
        "parentId": "",
        "imgUrl": null,
        "name": "Электроника",
        "description": "Описание Электроника",
        "level": 0,
        "fullPath": "Электроника",
        "subCategories": [
            {
                "id": "3-1",
                "parentId": "3",
                "imgUrl": null,
                "name": "Ноутбуки",
                "description": "Описание Ноутбуки",
                "level": 1,
                "fullPath": "3 > Ноутбуки",
                "subCategories": [
                    {
                        "id": "3-1-1",
                        "parentId": "3-1",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "3-1 > Dell",
                        "subCategories": [
                            {
                                "id": "3-1-1-1",
                                "parentId": "3-1-1",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-1-1 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-1-2",
                        "parentId": "3-1",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "3-1 > HP",
                        "subCategories": [
                            {
                                "id": "3-1-2-1",
                                "parentId": "3-1-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-1-2 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "3-1-2-2",
                                "parentId": "3-1-2",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-1-2 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-1-3",
                        "parentId": "3-1",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "3-1 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "3-1-3-1",
                                "parentId": "3-1-3",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-1-3 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "3-1-3-2",
                                "parentId": "3-1-3",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-1-3 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-1-4",
                        "parentId": "3-1",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "3-1 > Sony",
                        "subCategories": [
                            {
                                "id": "3-1-4-1",
                                "parentId": "3-1-4",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-1-4 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "3-1-4-2",
                                "parentId": "3-1-4",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-1-4 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-1-5",
                        "parentId": "3-1",
                        "imgUrl": null,
                        "name": "Nikon",
                        "description": "Описание Nikon",
                        "level": 2,
                        "fullPath": "3-1 > Nikon",
                        "subCategories": [
                            {
                                "id": "3-1-5-1",
                                "parentId": "3-1-5",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-1-5 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-1-6",
                        "parentId": "3-1",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "3-1 > Dell",
                        "subCategories": [
                            {
                                "id": "3-1-6-1",
                                "parentId": "3-1-6",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-1-6 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "3-1-6-2",
                                "parentId": "3-1-6",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-1-6 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-1-7",
                        "parentId": "3-1",
                        "imgUrl": null,
                        "name": "Canon",
                        "description": "Описание Canon",
                        "level": 2,
                        "fullPath": "3-1 > Canon",
                        "subCategories": [
                            {
                                "id": "3-1-7-1",
                                "parentId": "3-1-7",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-1-7 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-1-8",
                        "parentId": "3-1",
                        "imgUrl": null,
                        "name": "Apple",
                        "description": "Описание Apple",
                        "level": 2,
                        "fullPath": "3-1 > Apple",
                        "subCategories": [
                            {
                                "id": "3-1-8-1",
                                "parentId": "3-1-8",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-1-8 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "3-1-8-2",
                                "parentId": "3-1-8",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-1-8 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-1-9",
                        "parentId": "3-1",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "3-1 > LG",
                        "subCategories": [
                            {
                                "id": "3-1-9-1",
                                "parentId": "3-1-9",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-1-9 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "3-1-9-2",
                                "parentId": "3-1-9",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-1-9 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-1-10",
                        "parentId": "3-1",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "3-1 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "3-1-10-1",
                                "parentId": "3-1-10",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-1-10 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            },
            {
                "id": "3-2",
                "parentId": "3",
                "imgUrl": null,
                "name": "Ноутбуки",
                "description": "Описание Ноутбуки",
                "level": 1,
                "fullPath": "3 > Ноутбуки",
                "subCategories": [
                    {
                        "id": "3-2-1",
                        "parentId": "3-2",
                        "imgUrl": null,
                        "name": "Samsung",
                        "description": "Описание Samsung",
                        "level": 2,
                        "fullPath": "3-2 > Samsung",
                        "subCategories": [
                            {
                                "id": "3-2-1-1",
                                "parentId": "3-2-1",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-2-1 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "3-2-1-2",
                                "parentId": "3-2-1",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-2-1 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-2-2",
                        "parentId": "3-2",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "3-2 > HP",
                        "subCategories": [
                            {
                                "id": "3-2-2-1",
                                "parentId": "3-2-2",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-2-2 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "3-2-2-2",
                                "parentId": "3-2-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-2-2 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-2-3",
                        "parentId": "3-2",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "3-2 > Sony",
                        "subCategories": [
                            {
                                "id": "3-2-3-1",
                                "parentId": "3-2-3",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-2-3 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "3-2-3-2",
                                "parentId": "3-2-3",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-2-3 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-2-4",
                        "parentId": "3-2",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "3-2 > Sony",
                        "subCategories": [
                            {
                                "id": "3-2-4-1",
                                "parentId": "3-2-4",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-2-4 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-2-5",
                        "parentId": "3-2",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "3-2 > Dell",
                        "subCategories": [
                            {
                                "id": "3-2-5-1",
                                "parentId": "3-2-5",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-2-5 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-2-6",
                        "parentId": "3-2",
                        "imgUrl": null,
                        "name": "Canon",
                        "description": "Описание Canon",
                        "level": 2,
                        "fullPath": "3-2 > Canon",
                        "subCategories": [
                            {
                                "id": "3-2-6-1",
                                "parentId": "3-2-6",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-2-6 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-2-7",
                        "parentId": "3-2",
                        "imgUrl": null,
                        "name": "Samsung",
                        "description": "Описание Samsung",
                        "level": 2,
                        "fullPath": "3-2 > Samsung",
                        "subCategories": [
                            {
                                "id": "3-2-7-1",
                                "parentId": "3-2-7",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-2-7 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "3-2-7-2",
                                "parentId": "3-2-7",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-2-7 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-2-8",
                        "parentId": "3-2",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "3-2 > Asus",
                        "subCategories": [
                            {
                                "id": "3-2-8-1",
                                "parentId": "3-2-8",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-2-8 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-2-9",
                        "parentId": "3-2",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "3-2 > HP",
                        "subCategories": [
                            {
                                "id": "3-2-9-1",
                                "parentId": "3-2-9",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-2-9 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-2-10",
                        "parentId": "3-2",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "3-2 > HP",
                        "subCategories": [
                            {
                                "id": "3-2-10-1",
                                "parentId": "3-2-10",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-2-10 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            },
            {
                "id": "3-3",
                "parentId": "3",
                "imgUrl": null,
                "name": "Телевизоры",
                "description": "Описание Телевизоры",
                "level": 1,
                "fullPath": "3 > Телевизоры",
                "subCategories": [
                    {
                        "id": "3-3-1",
                        "parentId": "3-3",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "3-3 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "3-3-1-1",
                                "parentId": "3-3-1",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-3-1 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "3-3-1-2",
                                "parentId": "3-3-1",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-3-1 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-3-2",
                        "parentId": "3-3",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "3-3 > Dell",
                        "subCategories": [
                            {
                                "id": "3-3-2-1",
                                "parentId": "3-3-2",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-3-2 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-3-3",
                        "parentId": "3-3",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "3-3 > Dell",
                        "subCategories": [
                            {
                                "id": "3-3-3-1",
                                "parentId": "3-3-3",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-3-3 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-3-4",
                        "parentId": "3-3",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "3-3 > LG",
                        "subCategories": [
                            {
                                "id": "3-3-4-1",
                                "parentId": "3-3-4",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-3-4 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-3-5",
                        "parentId": "3-3",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "3-3 > Dell",
                        "subCategories": [
                            {
                                "id": "3-3-5-1",
                                "parentId": "3-3-5",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-3-5 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "3-3-5-2",
                                "parentId": "3-3-5",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-3-5 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-3-6",
                        "parentId": "3-3",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "3-3 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "3-3-6-1",
                                "parentId": "3-3-6",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-3-6 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "3-3-6-2",
                                "parentId": "3-3-6",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-3-6 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-3-7",
                        "parentId": "3-3",
                        "imgUrl": null,
                        "name": "Samsung",
                        "description": "Описание Samsung",
                        "level": 2,
                        "fullPath": "3-3 > Samsung",
                        "subCategories": [
                            {
                                "id": "3-3-7-1",
                                "parentId": "3-3-7",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-3-7 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-3-8",
                        "parentId": "3-3",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "3-3 > LG",
                        "subCategories": [
                            {
                                "id": "3-3-8-1",
                                "parentId": "3-3-8",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-3-8 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "3-3-8-2",
                                "parentId": "3-3-8",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-3-8 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-3-9",
                        "parentId": "3-3",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "3-3 > Asus",
                        "subCategories": [
                            {
                                "id": "3-3-9-1",
                                "parentId": "3-3-9",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-3-9 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-3-10",
                        "parentId": "3-3",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "3-3 > LG",
                        "subCategories": [
                            {
                                "id": "3-3-10-1",
                                "parentId": "3-3-10",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-3-10 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            },
            {
                "id": "3-4",
                "parentId": "3",
                "imgUrl": null,
                "name": "Телевизоры",
                "description": "Описание Телевизоры",
                "level": 1,
                "fullPath": "3 > Телевизоры",
                "subCategories": [
                    {
                        "id": "3-4-1",
                        "parentId": "3-4",
                        "imgUrl": null,
                        "name": "Samsung",
                        "description": "Описание Samsung",
                        "level": 2,
                        "fullPath": "3-4 > Samsung",
                        "subCategories": [
                            {
                                "id": "3-4-1-1",
                                "parentId": "3-4-1",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-4-1 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "3-4-1-2",
                                "parentId": "3-4-1",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-4-1 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-4-2",
                        "parentId": "3-4",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "3-4 > Asus",
                        "subCategories": [
                            {
                                "id": "3-4-2-1",
                                "parentId": "3-4-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-4-2 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-4-3",
                        "parentId": "3-4",
                        "imgUrl": null,
                        "name": "Samsung",
                        "description": "Описание Samsung",
                        "level": 2,
                        "fullPath": "3-4 > Samsung",
                        "subCategories": [
                            {
                                "id": "3-4-3-1",
                                "parentId": "3-4-3",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-4-3 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "3-4-3-2",
                                "parentId": "3-4-3",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-4-3 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-4-4",
                        "parentId": "3-4",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "3-4 > HP",
                        "subCategories": [
                            {
                                "id": "3-4-4-1",
                                "parentId": "3-4-4",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-4-4 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-4-5",
                        "parentId": "3-4",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "3-4 > Dell",
                        "subCategories": [
                            {
                                "id": "3-4-5-1",
                                "parentId": "3-4-5",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-4-5 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-4-6",
                        "parentId": "3-4",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "3-4 > Asus",
                        "subCategories": [
                            {
                                "id": "3-4-6-1",
                                "parentId": "3-4-6",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-4-6 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "3-4-6-2",
                                "parentId": "3-4-6",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-4-6 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-4-7",
                        "parentId": "3-4",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "3-4 > HP",
                        "subCategories": [
                            {
                                "id": "3-4-7-1",
                                "parentId": "3-4-7",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-4-7 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-4-8",
                        "parentId": "3-4",
                        "imgUrl": null,
                        "name": "Apple",
                        "description": "Описание Apple",
                        "level": 2,
                        "fullPath": "3-4 > Apple",
                        "subCategories": [
                            {
                                "id": "3-4-8-1",
                                "parentId": "3-4-8",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-4-8 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "3-4-8-2",
                                "parentId": "3-4-8",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-4-8 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-4-9",
                        "parentId": "3-4",
                        "imgUrl": null,
                        "name": "Canon",
                        "description": "Описание Canon",
                        "level": 2,
                        "fullPath": "3-4 > Canon",
                        "subCategories": [
                            {
                                "id": "3-4-9-1",
                                "parentId": "3-4-9",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "3-4-9 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "3-4-10",
                        "parentId": "3-4",
                        "imgUrl": null,
                        "name": "Nikon",
                        "description": "Описание Nikon",
                        "level": 2,
                        "fullPath": "3-4 > Nikon",
                        "subCategories": [
                            {
                                "id": "3-4-10-1",
                                "parentId": "3-4-10",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "3-4-10 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            }
        ]
    },
    {
        "id": "4",
        "parentId": "",
        "imgUrl": null,
        "name": "Книги",
        "description": "Описание Книги",
        "level": 0,
        "fullPath": "Книги",
        "subCategories": [
            {
                "id": "4-1",
                "parentId": "4",
                "imgUrl": null,
                "name": "Ноутбуки",
                "description": "Описание Ноутбуки",
                "level": 1,
                "fullPath": "4 > Ноутбуки",
                "subCategories": [
                    {
                        "id": "4-1-1",
                        "parentId": "4-1",
                        "imgUrl": null,
                        "name": "Canon",
                        "description": "Описание Canon",
                        "level": 2,
                        "fullPath": "4-1 > Canon",
                        "subCategories": [
                            {
                                "id": "4-1-1-1",
                                "parentId": "4-1-1",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-1-1 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-1-2",
                        "parentId": "4-1",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "4-1 > Asus",
                        "subCategories": [
                            {
                                "id": "4-1-2-1",
                                "parentId": "4-1-2",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-1-2 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "4-1-2-2",
                                "parentId": "4-1-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-1-2 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-1-3",
                        "parentId": "4-1",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "4-1 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "4-1-3-1",
                                "parentId": "4-1-3",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-1-3 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-1-4",
                        "parentId": "4-1",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "4-1 > Dell",
                        "subCategories": [
                            {
                                "id": "4-1-4-1",
                                "parentId": "4-1-4",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-1-4 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "4-1-4-2",
                                "parentId": "4-1-4",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-1-4 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-1-5",
                        "parentId": "4-1",
                        "imgUrl": null,
                        "name": "Samsung",
                        "description": "Описание Samsung",
                        "level": 2,
                        "fullPath": "4-1 > Samsung",
                        "subCategories": [
                            {
                                "id": "4-1-5-1",
                                "parentId": "4-1-5",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-1-5 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "4-1-5-2",
                                "parentId": "4-1-5",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-1-5 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-1-6",
                        "parentId": "4-1",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "4-1 > Sony",
                        "subCategories": [
                            {
                                "id": "4-1-6-1",
                                "parentId": "4-1-6",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-1-6 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "4-1-6-2",
                                "parentId": "4-1-6",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-1-6 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-1-7",
                        "parentId": "4-1",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "4-1 > HP",
                        "subCategories": [
                            {
                                "id": "4-1-7-1",
                                "parentId": "4-1-7",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-1-7 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-1-8",
                        "parentId": "4-1",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "4-1 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "4-1-8-1",
                                "parentId": "4-1-8",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-1-8 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-1-9",
                        "parentId": "4-1",
                        "imgUrl": null,
                        "name": "Nikon",
                        "description": "Описание Nikon",
                        "level": 2,
                        "fullPath": "4-1 > Nikon",
                        "subCategories": [
                            {
                                "id": "4-1-9-1",
                                "parentId": "4-1-9",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-1-9 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "4-1-9-2",
                                "parentId": "4-1-9",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-1-9 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-1-10",
                        "parentId": "4-1",
                        "imgUrl": null,
                        "name": "Apple",
                        "description": "Описание Apple",
                        "level": 2,
                        "fullPath": "4-1 > Apple",
                        "subCategories": [
                            {
                                "id": "4-1-10-1",
                                "parentId": "4-1-10",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-1-10 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "4-1-10-2",
                                "parentId": "4-1-10",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-1-10 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            },
            {
                "id": "4-2",
                "parentId": "4",
                "imgUrl": null,
                "name": "Фотоаппараты",
                "description": "Описание Фотоаппараты",
                "level": 1,
                "fullPath": "4 > Фотоаппараты",
                "subCategories": [
                    {
                        "id": "4-2-1",
                        "parentId": "4-2",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "4-2 > Asus",
                        "subCategories": [
                            {
                                "id": "4-2-1-1",
                                "parentId": "4-2-1",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-2-1 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-2-2",
                        "parentId": "4-2",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "4-2 > Dell",
                        "subCategories": [
                            {
                                "id": "4-2-2-1",
                                "parentId": "4-2-2",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-2-2 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-2-3",
                        "parentId": "4-2",
                        "imgUrl": null,
                        "name": "Nikon",
                        "description": "Описание Nikon",
                        "level": 2,
                        "fullPath": "4-2 > Nikon",
                        "subCategories": [
                            {
                                "id": "4-2-3-1",
                                "parentId": "4-2-3",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-2-3 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-2-4",
                        "parentId": "4-2",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "4-2 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "4-2-4-1",
                                "parentId": "4-2-4",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-2-4 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "4-2-4-2",
                                "parentId": "4-2-4",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-2-4 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-2-5",
                        "parentId": "4-2",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "4-2 > Dell",
                        "subCategories": [
                            {
                                "id": "4-2-5-1",
                                "parentId": "4-2-5",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-2-5 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-2-6",
                        "parentId": "4-2",
                        "imgUrl": null,
                        "name": "Samsung",
                        "description": "Описание Samsung",
                        "level": 2,
                        "fullPath": "4-2 > Samsung",
                        "subCategories": [
                            {
                                "id": "4-2-6-1",
                                "parentId": "4-2-6",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-2-6 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "4-2-6-2",
                                "parentId": "4-2-6",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-2-6 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-2-7",
                        "parentId": "4-2",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "4-2 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "4-2-7-1",
                                "parentId": "4-2-7",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-2-7 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "4-2-7-2",
                                "parentId": "4-2-7",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-2-7 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-2-8",
                        "parentId": "4-2",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "4-2 > HP",
                        "subCategories": [
                            {
                                "id": "4-2-8-1",
                                "parentId": "4-2-8",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-2-8 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "4-2-8-2",
                                "parentId": "4-2-8",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-2-8 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-2-9",
                        "parentId": "4-2",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "4-2 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "4-2-9-1",
                                "parentId": "4-2-9",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-2-9 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "4-2-9-2",
                                "parentId": "4-2-9",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-2-9 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-2-10",
                        "parentId": "4-2",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "4-2 > Asus",
                        "subCategories": [
                            {
                                "id": "4-2-10-1",
                                "parentId": "4-2-10",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-2-10 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            },
            {
                "id": "4-3",
                "parentId": "4",
                "imgUrl": null,
                "name": "Смартфоны",
                "description": "Описание Смартфоны",
                "level": 1,
                "fullPath": "4 > Смартфоны",
                "subCategories": [
                    {
                        "id": "4-3-1",
                        "parentId": "4-3",
                        "imgUrl": null,
                        "name": "Apple",
                        "description": "Описание Apple",
                        "level": 2,
                        "fullPath": "4-3 > Apple",
                        "subCategories": [
                            {
                                "id": "4-3-1-1",
                                "parentId": "4-3-1",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-3-1 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-3-2",
                        "parentId": "4-3",
                        "imgUrl": null,
                        "name": "Nikon",
                        "description": "Описание Nikon",
                        "level": 2,
                        "fullPath": "4-3 > Nikon",
                        "subCategories": [
                            {
                                "id": "4-3-2-1",
                                "parentId": "4-3-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-3-2 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "4-3-2-2",
                                "parentId": "4-3-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-3-2 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-3-3",
                        "parentId": "4-3",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "4-3 > LG",
                        "subCategories": [
                            {
                                "id": "4-3-3-1",
                                "parentId": "4-3-3",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-3-3 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "4-3-3-2",
                                "parentId": "4-3-3",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-3-3 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-3-4",
                        "parentId": "4-3",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "4-3 > Dell",
                        "subCategories": [
                            {
                                "id": "4-3-4-1",
                                "parentId": "4-3-4",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-3-4 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-3-5",
                        "parentId": "4-3",
                        "imgUrl": null,
                        "name": "Canon",
                        "description": "Описание Canon",
                        "level": 2,
                        "fullPath": "4-3 > Canon",
                        "subCategories": [
                            {
                                "id": "4-3-5-1",
                                "parentId": "4-3-5",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-3-5 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "4-3-5-2",
                                "parentId": "4-3-5",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-3-5 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-3-6",
                        "parentId": "4-3",
                        "imgUrl": null,
                        "name": "Nikon",
                        "description": "Описание Nikon",
                        "level": 2,
                        "fullPath": "4-3 > Nikon",
                        "subCategories": [
                            {
                                "id": "4-3-6-1",
                                "parentId": "4-3-6",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-3-6 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "4-3-6-2",
                                "parentId": "4-3-6",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-3-6 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-3-7",
                        "parentId": "4-3",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "4-3 > Asus",
                        "subCategories": [
                            {
                                "id": "4-3-7-1",
                                "parentId": "4-3-7",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-3-7 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "4-3-7-2",
                                "parentId": "4-3-7",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-3-7 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-3-8",
                        "parentId": "4-3",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "4-3 > HP",
                        "subCategories": [
                            {
                                "id": "4-3-8-1",
                                "parentId": "4-3-8",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-3-8 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "4-3-8-2",
                                "parentId": "4-3-8",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-3-8 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-3-9",
                        "parentId": "4-3",
                        "imgUrl": null,
                        "name": "Apple",
                        "description": "Описание Apple",
                        "level": 2,
                        "fullPath": "4-3 > Apple",
                        "subCategories": [
                            {
                                "id": "4-3-9-1",
                                "parentId": "4-3-9",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-3-9 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-3-10",
                        "parentId": "4-3",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "4-3 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "4-3-10-1",
                                "parentId": "4-3-10",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-3-10 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            },
            {
                "id": "4-4",
                "parentId": "4",
                "imgUrl": null,
                "name": "Фотоаппараты",
                "description": "Описание Фотоаппараты",
                "level": 1,
                "fullPath": "4 > Фотоаппараты",
                "subCategories": [
                    {
                        "id": "4-4-1",
                        "parentId": "4-4",
                        "imgUrl": null,
                        "name": "Samsung",
                        "description": "Описание Samsung",
                        "level": 2,
                        "fullPath": "4-4 > Samsung",
                        "subCategories": [
                            {
                                "id": "4-4-1-1",
                                "parentId": "4-4-1",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-4-1 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "4-4-1-2",
                                "parentId": "4-4-1",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-4-1 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-4-2",
                        "parentId": "4-4",
                        "imgUrl": null,
                        "name": "Canon",
                        "description": "Описание Canon",
                        "level": 2,
                        "fullPath": "4-4 > Canon",
                        "subCategories": [
                            {
                                "id": "4-4-2-1",
                                "parentId": "4-4-2",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-4-2 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-4-3",
                        "parentId": "4-4",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "4-4 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "4-4-3-1",
                                "parentId": "4-4-3",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-4-3 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-4-4",
                        "parentId": "4-4",
                        "imgUrl": null,
                        "name": "Nikon",
                        "description": "Описание Nikon",
                        "level": 2,
                        "fullPath": "4-4 > Nikon",
                        "subCategories": [
                            {
                                "id": "4-4-4-1",
                                "parentId": "4-4-4",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-4-4 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "4-4-4-2",
                                "parentId": "4-4-4",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-4-4 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-4-5",
                        "parentId": "4-4",
                        "imgUrl": null,
                        "name": "Nikon",
                        "description": "Описание Nikon",
                        "level": 2,
                        "fullPath": "4-4 > Nikon",
                        "subCategories": [
                            {
                                "id": "4-4-5-1",
                                "parentId": "4-4-5",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-4-5 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "4-4-5-2",
                                "parentId": "4-4-5",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-4-5 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-4-6",
                        "parentId": "4-4",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "4-4 > Asus",
                        "subCategories": [
                            {
                                "id": "4-4-6-1",
                                "parentId": "4-4-6",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-4-6 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "4-4-6-2",
                                "parentId": "4-4-6",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-4-6 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-4-7",
                        "parentId": "4-4",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "4-4 > LG",
                        "subCategories": [
                            {
                                "id": "4-4-7-1",
                                "parentId": "4-4-7",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-4-7 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "4-4-7-2",
                                "parentId": "4-4-7",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-4-7 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-4-8",
                        "parentId": "4-4",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "4-4 > LG",
                        "subCategories": [
                            {
                                "id": "4-4-8-1",
                                "parentId": "4-4-8",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-4-8 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "4-4-8-2",
                                "parentId": "4-4-8",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-4-8 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-4-9",
                        "parentId": "4-4",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "4-4 > LG",
                        "subCategories": [
                            {
                                "id": "4-4-9-1",
                                "parentId": "4-4-9",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-4-9 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "4-4-10",
                        "parentId": "4-4",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "4-4 > Asus",
                        "subCategories": [
                            {
                                "id": "4-4-10-1",
                                "parentId": "4-4-10",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "4-4-10 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "4-4-10-2",
                                "parentId": "4-4-10",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "4-4-10 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            }
        ]
    },
    {
        "id": "5",
        "parentId": "",
        "imgUrl": null,
        "name": "Бытовая техника",
        "description": "Описание Бытовая техника",
        "level": 0,
        "fullPath": "Бытовая техника",
        "subCategories": [
            {
                "id": "5-1",
                "parentId": "5",
                "imgUrl": null,
                "name": "Фотоаппараты",
                "description": "Описание Фотоаппараты",
                "level": 1,
                "fullPath": "5 > Фотоаппараты",
                "subCategories": [
                    {
                        "id": "5-1-1",
                        "parentId": "5-1",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "5-1 > HP",
                        "subCategories": [
                            {
                                "id": "5-1-1-1",
                                "parentId": "5-1-1",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-1-1 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "5-1-1-2",
                                "parentId": "5-1-1",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-1-1 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-1-2",
                        "parentId": "5-1",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "5-1 > Sony",
                        "subCategories": [
                            {
                                "id": "5-1-2-1",
                                "parentId": "5-1-2",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-1-2 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-1-3",
                        "parentId": "5-1",
                        "imgUrl": null,
                        "name": "Apple",
                        "description": "Описание Apple",
                        "level": 2,
                        "fullPath": "5-1 > Apple",
                        "subCategories": [
                            {
                                "id": "5-1-3-1",
                                "parentId": "5-1-3",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-1-3 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-1-4",
                        "parentId": "5-1",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "5-1 > Asus",
                        "subCategories": [
                            {
                                "id": "5-1-4-1",
                                "parentId": "5-1-4",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-1-4 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-1-5",
                        "parentId": "5-1",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "5-1 > Asus",
                        "subCategories": [
                            {
                                "id": "5-1-5-1",
                                "parentId": "5-1-5",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-1-5 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-1-6",
                        "parentId": "5-1",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "5-1 > HP",
                        "subCategories": [
                            {
                                "id": "5-1-6-1",
                                "parentId": "5-1-6",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-1-6 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-1-7",
                        "parentId": "5-1",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "5-1 > Sony",
                        "subCategories": [
                            {
                                "id": "5-1-7-1",
                                "parentId": "5-1-7",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-1-7 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "5-1-7-2",
                                "parentId": "5-1-7",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-1-7 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-1-8",
                        "parentId": "5-1",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "5-1 > LG",
                        "subCategories": [
                            {
                                "id": "5-1-8-1",
                                "parentId": "5-1-8",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-1-8 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-1-9",
                        "parentId": "5-1",
                        "imgUrl": null,
                        "name": "Nikon",
                        "description": "Описание Nikon",
                        "level": 2,
                        "fullPath": "5-1 > Nikon",
                        "subCategories": [
                            {
                                "id": "5-1-9-1",
                                "parentId": "5-1-9",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-1-9 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-1-10",
                        "parentId": "5-1",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "5-1 > LG",
                        "subCategories": [
                            {
                                "id": "5-1-10-1",
                                "parentId": "5-1-10",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-1-10 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "5-1-10-2",
                                "parentId": "5-1-10",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-1-10 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            },
            {
                "id": "5-2",
                "parentId": "5",
                "imgUrl": null,
                "name": "Смартфоны",
                "description": "Описание Смартфоны",
                "level": 1,
                "fullPath": "5 > Смартфоны",
                "subCategories": [
                    {
                        "id": "5-2-1",
                        "parentId": "5-2",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "5-2 > Asus",
                        "subCategories": [
                            {
                                "id": "5-2-1-1",
                                "parentId": "5-2-1",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-2-1 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-2-2",
                        "parentId": "5-2",
                        "imgUrl": null,
                        "name": "Nikon",
                        "description": "Описание Nikon",
                        "level": 2,
                        "fullPath": "5-2 > Nikon",
                        "subCategories": [
                            {
                                "id": "5-2-2-1",
                                "parentId": "5-2-2",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-2-2 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-2-3",
                        "parentId": "5-2",
                        "imgUrl": null,
                        "name": "Canon",
                        "description": "Описание Canon",
                        "level": 2,
                        "fullPath": "5-2 > Canon",
                        "subCategories": [
                            {
                                "id": "5-2-3-1",
                                "parentId": "5-2-3",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-2-3 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "5-2-3-2",
                                "parentId": "5-2-3",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-2-3 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-2-4",
                        "parentId": "5-2",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "5-2 > HP",
                        "subCategories": [
                            {
                                "id": "5-2-4-1",
                                "parentId": "5-2-4",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-2-4 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "5-2-4-2",
                                "parentId": "5-2-4",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-2-4 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-2-5",
                        "parentId": "5-2",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "5-2 > Sony",
                        "subCategories": [
                            {
                                "id": "5-2-5-1",
                                "parentId": "5-2-5",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-2-5 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "5-2-5-2",
                                "parentId": "5-2-5",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-2-5 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-2-6",
                        "parentId": "5-2",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "5-2 > Sony",
                        "subCategories": [
                            {
                                "id": "5-2-6-1",
                                "parentId": "5-2-6",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-2-6 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "5-2-6-2",
                                "parentId": "5-2-6",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-2-6 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-2-7",
                        "parentId": "5-2",
                        "imgUrl": null,
                        "name": "Samsung",
                        "description": "Описание Samsung",
                        "level": 2,
                        "fullPath": "5-2 > Samsung",
                        "subCategories": [
                            {
                                "id": "5-2-7-1",
                                "parentId": "5-2-7",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-2-7 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "5-2-7-2",
                                "parentId": "5-2-7",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-2-7 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-2-8",
                        "parentId": "5-2",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "5-2 > HP",
                        "subCategories": [
                            {
                                "id": "5-2-8-1",
                                "parentId": "5-2-8",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-2-8 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "5-2-8-2",
                                "parentId": "5-2-8",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-2-8 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-2-9",
                        "parentId": "5-2",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "5-2 > Sony",
                        "subCategories": [
                            {
                                "id": "5-2-9-1",
                                "parentId": "5-2-9",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-2-9 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "5-2-9-2",
                                "parentId": "5-2-9",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-2-9 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-2-10",
                        "parentId": "5-2",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "5-2 > HP",
                        "subCategories": [
                            {
                                "id": "5-2-10-1",
                                "parentId": "5-2-10",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-2-10 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "5-2-10-2",
                                "parentId": "5-2-10",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-2-10 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            },
            {
                "id": "5-3",
                "parentId": "5",
                "imgUrl": null,
                "name": "Смартфоны",
                "description": "Описание Смартфоны",
                "level": 1,
                "fullPath": "5 > Смартфоны",
                "subCategories": [
                    {
                        "id": "5-3-1",
                        "parentId": "5-3",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "5-3 > Sony",
                        "subCategories": [
                            {
                                "id": "5-3-1-1",
                                "parentId": "5-3-1",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-3-1 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "5-3-1-2",
                                "parentId": "5-3-1",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-3-1 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-3-2",
                        "parentId": "5-3",
                        "imgUrl": null,
                        "name": "Samsung",
                        "description": "Описание Samsung",
                        "level": 2,
                        "fullPath": "5-3 > Samsung",
                        "subCategories": [
                            {
                                "id": "5-3-2-1",
                                "parentId": "5-3-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-3-2 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "5-3-2-2",
                                "parentId": "5-3-2",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-3-2 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-3-3",
                        "parentId": "5-3",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "5-3 > HP",
                        "subCategories": [
                            {
                                "id": "5-3-3-1",
                                "parentId": "5-3-3",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-3-3 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "5-3-3-2",
                                "parentId": "5-3-3",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-3-3 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-3-4",
                        "parentId": "5-3",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "5-3 > Dell",
                        "subCategories": [
                            {
                                "id": "5-3-4-1",
                                "parentId": "5-3-4",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-3-4 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "5-3-4-2",
                                "parentId": "5-3-4",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-3-4 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-3-5",
                        "parentId": "5-3",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "5-3 > HP",
                        "subCategories": [
                            {
                                "id": "5-3-5-1",
                                "parentId": "5-3-5",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-3-5 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-3-6",
                        "parentId": "5-3",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "5-3 > Sony",
                        "subCategories": [
                            {
                                "id": "5-3-6-1",
                                "parentId": "5-3-6",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-3-6 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "5-3-6-2",
                                "parentId": "5-3-6",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-3-6 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-3-7",
                        "parentId": "5-3",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "5-3 > LG",
                        "subCategories": [
                            {
                                "id": "5-3-7-1",
                                "parentId": "5-3-7",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-3-7 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-3-8",
                        "parentId": "5-3",
                        "imgUrl": null,
                        "name": "Canon",
                        "description": "Описание Canon",
                        "level": 2,
                        "fullPath": "5-3 > Canon",
                        "subCategories": [
                            {
                                "id": "5-3-8-1",
                                "parentId": "5-3-8",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-3-8 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-3-9",
                        "parentId": "5-3",
                        "imgUrl": null,
                        "name": "Samsung",
                        "description": "Описание Samsung",
                        "level": 2,
                        "fullPath": "5-3 > Samsung",
                        "subCategories": [
                            {
                                "id": "5-3-9-1",
                                "parentId": "5-3-9",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-3-9 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-3-10",
                        "parentId": "5-3",
                        "imgUrl": null,
                        "name": "Nikon",
                        "description": "Описание Nikon",
                        "level": 2,
                        "fullPath": "5-3 > Nikon",
                        "subCategories": [
                            {
                                "id": "5-3-10-1",
                                "parentId": "5-3-10",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-3-10 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "5-3-10-2",
                                "parentId": "5-3-10",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-3-10 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            },
            {
                "id": "5-4",
                "parentId": "5",
                "imgUrl": null,
                "name": "Смартфоны",
                "description": "Описание Смартфоны",
                "level": 1,
                "fullPath": "5 > Смартфоны",
                "subCategories": [
                    {
                        "id": "5-4-1",
                        "parentId": "5-4",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "5-4 > LG",
                        "subCategories": [
                            {
                                "id": "5-4-1-1",
                                "parentId": "5-4-1",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-4-1 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "5-4-1-2",
                                "parentId": "5-4-1",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-4-1 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-4-2",
                        "parentId": "5-4",
                        "imgUrl": null,
                        "name": "Dell",
                        "description": "Описание Dell",
                        "level": 2,
                        "fullPath": "5-4 > Dell",
                        "subCategories": [
                            {
                                "id": "5-4-2-1",
                                "parentId": "5-4-2",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-4-2 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "5-4-2-2",
                                "parentId": "5-4-2",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-4-2 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-4-3",
                        "parentId": "5-4",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "5-4 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "5-4-3-1",
                                "parentId": "5-4-3",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-4-3 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-4-4",
                        "parentId": "5-4",
                        "imgUrl": null,
                        "name": "HP",
                        "description": "Описание HP",
                        "level": 2,
                        "fullPath": "5-4 > HP",
                        "subCategories": [
                            {
                                "id": "5-4-4-1",
                                "parentId": "5-4-4",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-4-4 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-4-5",
                        "parentId": "5-4",
                        "imgUrl": null,
                        "name": "Nikon",
                        "description": "Описание Nikon",
                        "level": 2,
                        "fullPath": "5-4 > Nikon",
                        "subCategories": [
                            {
                                "id": "5-4-5-1",
                                "parentId": "5-4-5",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-4-5 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "5-4-5-2",
                                "parentId": "5-4-5",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-4-5 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-4-6",
                        "parentId": "5-4",
                        "imgUrl": null,
                        "name": "Sony",
                        "description": "Описание Sony",
                        "level": 2,
                        "fullPath": "5-4 > Sony",
                        "subCategories": [
                            {
                                "id": "5-4-6-1",
                                "parentId": "5-4-6",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-4-6 > Зарядные устройства",
                                "subCategories": []
                            },
                            {
                                "id": "5-4-6-2",
                                "parentId": "5-4-6",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-4-6 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-4-7",
                        "parentId": "5-4",
                        "imgUrl": null,
                        "name": "Xiaomi",
                        "description": "Описание Xiaomi",
                        "level": 2,
                        "fullPath": "5-4 > Xiaomi",
                        "subCategories": [
                            {
                                "id": "5-4-7-1",
                                "parentId": "5-4-7",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-4-7 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-4-8",
                        "parentId": "5-4",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "5-4 > LG",
                        "subCategories": [
                            {
                                "id": "5-4-8-1",
                                "parentId": "5-4-8",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-4-8 > Аксессуары",
                                "subCategories": []
                            },
                            {
                                "id": "5-4-8-2",
                                "parentId": "5-4-8",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-4-8 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-4-9",
                        "parentId": "5-4",
                        "imgUrl": null,
                        "name": "LG",
                        "description": "Описание LG",
                        "level": 2,
                        "fullPath": "5-4 > LG",
                        "subCategories": [
                            {
                                "id": "5-4-9-1",
                                "parentId": "5-4-9",
                                "imgUrl": null,
                                "name": "Зарядные устройства",
                                "description": "Описание Зарядные устройства",
                                "level": 3,
                                "fullPath": "5-4-9 > Зарядные устройства",
                                "subCategories": []
                            }
                        ]
                    },
                    {
                        "id": "5-4-10",
                        "parentId": "5-4",
                        "imgUrl": null,
                        "name": "Asus",
                        "description": "Описание Asus",
                        "level": 2,
                        "fullPath": "5-4 > Asus",
                        "subCategories": [
                            {
                                "id": "5-4-10-1",
                                "parentId": "5-4-10",
                                "imgUrl": null,
                                "name": "Аксессуары",
                                "description": "Описание Аксессуары",
                                "level": 3,
                                "fullPath": "5-4-10 > Аксессуары",
                                "subCategories": []
                            }
                        ]
                    }
                ]
            }
        ]
    }
];


const initialState: CategoryState = {
    categories: _categories,
    activeCategory: null,
    isOpenCategoryMenu: false
};

const categorySlice = createSlice({
    name: "categories",
    initialState,
    reducers: {
        setActiveCategory: (state, action: PayloadAction<CategoryDto | null>) => {
            state.activeCategory = action.payload;
        },
        toggleOpenCategoryMenu: (state) => {
            state.isOpenCategoryMenu = !state.isOpenCategoryMenu;
        },
    },
});

export const { setActiveCategory, toggleOpenCategoryMenu } = categorySlice.actions;
export default categorySlice.reducer;
