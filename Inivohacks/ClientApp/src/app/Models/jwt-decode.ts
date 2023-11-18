export class jwtDecodeModel{
  FirstName: string;
  LastName: string;
  Username: string;
  isManufacturer: boolean;
  isSupplier: boolean;

  constructor() {
    this.FirstName = '';
    this.LastName = '';
    this.Username = '';
    this.isManufacturer = false;
    this.isSupplier = false;
  }
}
