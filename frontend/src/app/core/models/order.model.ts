export interface OrderItem {
  productId: string;
  productName: string;
  quantity: number;
  unitPrice: number;
  subtotal: number;
}

export interface Order {
  id: string;
  customerId: string;
  status: 'Pending' | 'Completed';
  total: number;
  createdAt: string;
  items: OrderItem[];
}
