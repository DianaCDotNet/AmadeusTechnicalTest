export interface ResponseUser {
  type: string;
  title: string;
  status: number;
  detail: string;
  instance: string;
  errors: {
    additionalProp1: string[];
    additionalProp2: string[];
    additionalProp3: string[];
  };
  additionalProp1: string;
  additionalProp2: string;
  additionalProp3: string;
}