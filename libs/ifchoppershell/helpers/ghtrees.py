import Grasshopper.Kernel as gh

def have_trees_same_shape(
        tree1: gh.GH_Structure,
        tree2: gh.GH_Structure
    ) -> bool:
    """
    Compares two Grasshopper Data Trees to check if they have the same set of 
    branch paths AND the same number of items in each corresponding branch.
    
    Args:
        tree1 (GH_Structure): The first Data Tree.
        tree2 (GH_Structure): The second Data Tree.
        
    Returns:
        bool: True if both shape and counts are identical, False otherwise.
    """
    
    # 1. Check Path Count
    if tree1.BranchCount != tree2.BranchCount:
        return False

    # 2. Get and sort the paths for consistent iteration
    # We convert to string and sort to ensure we check the correct corresponding paths.
    paths_A = sorted([path.ToString() for path in tree1.Paths])
    paths_B = sorted([path.ToString() for path in tree2.Paths])

    # If the sorted path names are different, the shapes are not identical.
    if paths_A != paths_B:
        return False
        
    # 3. Check Element Counts for each branch
    # Since paths_A and paths_B are sorted and equal, we can iterate simultaneously.
    for path_str in paths_A:
        
        # Convert the string path back to a GH_Path object to access the branch data
        # Note: We can simplify this by using the original tree1.Paths and tree2.Paths 
        # and checking the counts while iterating, but converting to strings first 
        # guarantees a paired iteration. A dictionary lookup is cleaner.
        
        # A simpler way is to build a dictionary of {path_string: count}
        
        # Build dictionaries of {PathString: BranchItemCount}
        branch_map_A = {p.ToString(): tree1.Branch(p).Count for p in tree1.Paths}
        branch_map_B = {p.ToString(): tree2.Branch(p).Count for p in tree2.Paths}
        
        # Compare the counts using the path string as the key
        if branch_map_A[path_str] != branch_map_B[path_str]:
            # The count of items in this specific branch is different
            return False

    # If all paths matched and all corresponding branch counts matched, they are identical in structure
    return True

def isinstance_tree(
        data_tree: gh.GH_Structure,
        expected_type: type
    ) -> bool:
    """
    Checks every single element in a Grasshopper DataTree against a specified Python type.

    Args:
        data_tree (GH_Structure): The input Data Tree.
        expected_type (type): The target Python type (e.g., int, float, str).

    Returns:
        bool: True if every element is of the expected type, False otherwise.
    """
    
    # 1. Iterate through all the paths (branches) in the tree
    for path in data_tree.Paths:
        # 2. Get the list of items for the current branch
        branch_data = data_tree.Branch(path)
        
        # Handle the case of empty branches (they don't violate the type constraint)
        if not branch_data:
            continue
            
        # 3. Iterate through every item in the current branch
        for item in branch_data:
            # 4. Perform the type check
            if not isinstance(item, expected_type):
                # If any item fails the check, we can stop immediately and return False
                return False

    # 5. If the loops complete without returning False, all elements matched the type
    return True