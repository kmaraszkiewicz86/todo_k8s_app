export interface GetToDoItemsResponse {
    id: number,
    title: string,
    description?: string,
    isCompleted: boolean,
    dueDate?: Date,
    createdAt: Date,
    updatedAt?: Date,
    priorityLevelName: string,
    categoryName: string,
    status: string,
    tags: string[]
  }

  export interface GetToDoItemCollectionResponse {
    items: GetToDoItemsResponse[],
    itemsCount: number
  }

  export interface GetToDoItemResult {
    value: GetToDoItemCollectionResponse,
  }
